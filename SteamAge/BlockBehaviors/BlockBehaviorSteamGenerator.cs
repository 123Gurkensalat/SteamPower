using SteamAge.BEBehaviors;
using SteamAge.Gui;

using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

using EnumLiquidDirection = Vintagestory.GameContent.BlockLiquidContainerBase.EnumLiquidDirection;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamGenerator : BlockBehavior
{
    public BlockBehaviorSteamGenerator(Block block) : base(block) { }

    public WaterTightContainableProps GetContainableProps(ItemStack stack) => BlockLiquidContainerBase.GetContainableProps(stack);

    private BEBehaviorSteamGenerator GetEntityBehavior(IWorldAccessor world, BlockSelection blockSel)
    {
        return world.BlockAccessor.GetBlockEntity(blockSel.Position)?.GetBehavior<BEBehaviorSteamGenerator>();
    }

    public override bool OnBlockInteractStart(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel, ref EnumHandling handling)
    {
        if (!HandleLiquidTransfer(world, byPlayer, blockSel))
        {
            HandleDialogGui(world, blockSel);
            handling = EnumHandling.Handled;
        }
        return true;
    }

    /// returns if LiquidTransfer was possible
    private bool HandleLiquidTransfer(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
    {
        ItemSlot activeHotbarSlot = byPlayer.InventoryManager.ActiveHotbarSlot;
        if (activeHotbarSlot.Empty)
            return false;

        if (activeHotbarSlot.Itemstack.Collectible is not ILiquidInterface)
            return false;

        var entityBehavior = GetEntityBehavior(world, blockSel);
        var collectible = activeHotbarSlot.Itemstack.Collectible;
        bool shiftKey = byPlayer.WorldData.EntityControls.ShiftKey;
        bool ctrlKey = byPlayer.WorldData.EntityControls.CtrlKey;


        // Try to put liquid from held item into container
        if (collectible is ILiquidSource objLso && objLso.AllowHeldLiquidTransfer)
        {
            ItemStack content = objLso.GetContent(activeHotbarSlot.Itemstack);
            if (content != null && content.Item.Code != "game:waterportion")
            {
                return false;
            }
            float desiredLitres = (ctrlKey ? objLso.TransferSizeLitres : objLso.CapacityLitres);
            var (stacks, litres) = GetTransferLitres(content, entityBehavior.Water, desiredLitres, 10f);
            if (stacks > 0)
            {
                content.StackSize -= stacks;
                entityBehavior.Water += litres;

                if (content.StackSize <= 0)
                {
                    (collectible as ILiquidSink).SetContent(activeHotbarSlot.Itemstack, null);
                }

                activeHotbarSlot.MarkDirty();
                entityBehavior.Blockentity.MarkDirty();
                DoLiquidMovedEffects(world, byPlayer, content, stacks, EnumLiquidDirection.Pour);
                return true;
            }
        }

        // Try to pull liquid from container into held item
        if (collectible is ILiquidSink objLsi && objLsi.AllowHeldLiquidTransfer)
        {
            var content = objLsi.GetContent(activeHotbarSlot.Itemstack);
            float desiredLitres = (ctrlKey ? objLsi.TransferSizeLitres : objLsi.CapacityLitres);

            if (content == null)
            {
                Item item = world.GetItem(new AssetLocation("game:waterportion"));
                objLsi.SetContent(activeHotbarSlot.Itemstack, new ItemStack(item, 0));
                content = objLsi.GetContent(activeHotbarSlot.Itemstack);
            }

            var (stacks, litres) = GetTransferLitres(activeHotbarSlot.Itemstack, entityBehavior.Water, content, desiredLitres, 10);
            if (stacks > 0)
            {
                entityBehavior.Water -= litres;
                content.StackSize += stacks;
                activeHotbarSlot.MarkDirty();
                entityBehavior.Blockentity.MarkDirty();
                DoLiquidMovedEffects(world, byPlayer, content, stacks, EnumLiquidDirection.Fill);
                return true;
            }
        }
        return false;
    }

    private void HandleDialogGui(IWorldAccessor world, BlockSelection blockSel)
    {
        var steamGenerator = GetEntityBehavior(world, blockSel);
        var steamContainer = steamGenerator.Blockentity.GetBehavior<BEBehaviorSteamContainer>();

        if (steamGenerator == null)
        {
            world.Api.Logger.Error("BlockBehaviorSteamGenerator has no corresponding BEBehaviorSteamGenerator");
            return;
        }

        if (world.Api is ICoreClientAPI capi)
        {
            var dialog = new GuiSteamGenerator(capi, steamGenerator, steamContainer);
            dialog.TryOpen();
        }
    }

    public void DoLiquidMovedEffects(IWorldAccessor world, IPlayer player, ItemStack contentStack, int moved, EnumLiquidDirection dir)
    {
        if (player != null)
        {
            WaterTightContainableProps containableProps = GetContainableProps(contentStack);
            float num = moved / containableProps.ItemsPerLitre;
            if (player is IClientPlayer cplayer)
            {
                cplayer.TriggerFpAnimation(EnumHandInteract.HeldItemInteract);
            }

            world.PlaySoundAt((dir == EnumLiquidDirection.Fill) ? containableProps.FillSound : containableProps.PourSound, player.Entity, player, true, 16f, GameMath.Clamp(num / 5f, 0.35f, 1f));
            world.SpawnCubeParticles(player.Entity.Pos.AheadCopy(0.25).XYZ.Add(0.0, player.Entity.SelectionBox.Y2 / 2.0, 0.0), contentStack, 0.75f, (int)num * 2, 0.45f, null, null);
        }
    }

    public (int, float) GetTransferLitres(ItemStack from, float to, float desiredLitres, float capacity)
    {
        WaterTightContainableProps props = GetContainableProps(from);
        if (props == null)
        {
            return (0, 0f);
        }

        float fromMaxLitres = from.StackSize * props.ItemsPerLitre;
        float toRemainingLitres = (int)((capacity - to) * props.ItemsPerLitre) / props.ItemsPerLitre;
        float transferLitres = GameMath.Min(desiredLitres, fromMaxLitres, toRemainingLitres);
        int stacks = (int)(transferLitres * props.ItemsPerLitre);
        return (stacks, transferLitres);
    }

    public (int, float) GetTransferLitres(ItemStack container, float from, ItemStack to, float desiredLitres, float capacity)
    {
        var toLiquidSink = container.Collectible as ILiquidSink;
        if (to == null)
        {
            return (0, 0f);
        }

        WaterTightContainableProps props = GetContainableProps(to);
        if (props == null)
        {
            return (0, 0f);
        }

        int fromMaxStacks = (int)(from * props.ItemsPerLitre);
        int toRemainingStacks = (int)(toLiquidSink.CapacityLitres * props.ItemsPerLitre) - to.StackSize;
        int transferStacks = GameMath.Min((int)(desiredLitres * props.ItemsPerLitre), fromMaxStacks, toRemainingStacks);
        float litres = transferStacks / props.ItemsPerLitre;
        return (transferStacks, litres);
    }
}
