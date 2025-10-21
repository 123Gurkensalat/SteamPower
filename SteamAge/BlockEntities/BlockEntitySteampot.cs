using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using Vintagestory.API.Datastructures;

using SteamAge.Power.Blocks;
using SteamAge.Power.Gui;
namespace SteamAge.Power.BlockEntities;

internal class BlockEntitySteampot : BlockEntityLiquidContainer
{
    private GuiDialogSteampot invDialog;

    private BlockSteampot ownBlock;

    public bool Sealed;

    public double SealedSinceTotalHours;

    public BarrelRecipe CurrentRecipe;

    public int CurrentOutSize;

    private bool ignoreChange;

    public int CapacityLitres { get; set; } = 50;

    public override string InventoryClassName => "barrel";

    public bool CanSeal => CurrentRecipe != null && CurrentRecipe.SealHours > 0.0;

    public BlockEntitySteampot()
    {
        inventory = new InventoryGeneric(2, null, null, (int id, InventoryGeneric self) => (id == 0) ? ((ItemSlot)new ItemSlotBarrelInput(self)) : ((ItemSlot)new ItemSlotLiquidOnly(self, 50f)));
        inventory.BaseWeight = 1f;
        //inventory.OnGetSuitability = GetSuitability;
        //inventory.SlotModified += Inventory_SlotModified;
        //inventory.OnAcquireTransitionSpeed += Inventory_OnAcquireTransitionSpeed1;
    }

    public override void Initialize(ICoreAPI api)
    {
        base.Initialize(api);
        ownBlock = base.Block as BlockSteampot;
        BlockSteampot blockBarrel = ownBlock;
        if (blockBarrel != null && blockBarrel.Attributes?["capacityLitres"].Exists == true)
        {
            CapacityLitres = ownBlock.Attributes["capacityLitres"].AsInt(50);
            (inventory[1] as ItemSlotLiquidOnly).CapacityLitres = CapacityLitres;
        }

        //if (api.Side == EnumAppSide.Client && currentMesh == null)
        if (api.Side == EnumAppSide.Client)
        {
            //currentMesh = GenMesh();
            //MarkDirty(redrawOnClient: true);
        }

        if (api.Side == EnumAppSide.Server)
        {
            //RegisterGameTickListener(OnEvery3Second, 3000);
        }

        //FindMatchingRecipe();



        //RegisterGameTickListener(EvaporateWaterEveryInterval, 2000);
    }

    private void EvaporateWaterEveryInterval(float dt)
    {

        ICoreClientAPI capi = Api as ICoreClientAPI;
        ItemStack stack = GetContent();
        int i = stack.StackSize;
        capi.ShowChatMessage("Steam Age: steampot current water level:" + i);
    }

    private void Inventory_SlotModified(int slotId)
    {
        if (!ignoreChange && (slotId == 0 || slotId == 1))
        {
            invDialog?.UpdateContents();
            ICoreAPI api = Api;
            if (api != null && api.Side == EnumAppSide.Client)
            {
                //currentMesh = GenMesh();
            }

            //MarkDirty(redrawOnClient: true);
            //    FindMatchingRecipe();
        }
    }

    public override void OnBlockBroken(IPlayer byPlayer = null)
    {
        if (!Sealed)
        {
            base.OnBlockBroken(byPlayer);
        }

        invDialog?.TryClose();
        invDialog = null;
    }

    public void OnPlayerRightClick(IPlayer byPlayer)
    {


        ICoreClientAPI capi = Api as ICoreClientAPI;
        Api.Logger.Notification("Steam Age: player right click");
        capi.ShowChatMessage("Steam Age: player right click");


        // int i = stack.StackSize;
        // capi.ShowChatMessage("Steam Age: steampot current water level:" + i);

        if (!Sealed)
        {
            //FindMatchingRecipe();
            if (Api.Side == EnumAppSide.Client)
            {
                toggleInventoryDialogClient(byPlayer);
            }
        }
    }

    protected void toggleInventoryDialogClient(IPlayer byPlayer)
    {
        ICoreClientAPI capi = Api as ICoreClientAPI;
        capi.ShowChatMessage("Steam Age: toggleInvetoryDialogClient activated");
        if (invDialog == null)
        {

            capi.ShowChatMessage("invDialog has been null");
            // invDialog = new GuiDialogSteampot(Lang.Get("Barrel"), Inventory, Pos, Api as ICoreClientAPI);
            invDialog = new GuiDialogSteampot(Lang.Get("Steampot"), Inventory, Pos, Api as ICoreClientAPI);
            invDialog.OnClosed += delegate
            {
                invDialog = null;
                capi.Network.SendBlockEntityPacket(Pos, 1001);
                capi.Network.SendPacketClient(Inventory.Close(byPlayer));
            };
            invDialog.OpenSound = AssetLocation.Create("sounds/block/barrelopen", base.Block.Code.Domain);
            invDialog.CloseSound = AssetLocation.Create("sounds/block/barrelclose", base.Block.Code.Domain);
            invDialog.TryOpen();
            capi.Network.SendPacketClient(Inventory.Open(byPlayer));
            capi.Network.SendBlockEntityPacket(Pos, 1000);
        }
        else
        {
            capi.ShowChatMessage("invDialog exists");
            invDialog.TryClose();
        }
    }

    public override void OnReceivedServerPacket(int packetid, byte[] data)
    {
        base.OnReceivedServerPacket(packetid, data);
        if (packetid == 1001)
        {
            (Api.World as IClientWorldAccessor).Player.InventoryManager.CloseInventory(Inventory);
            invDialog?.TryClose();
            invDialog?.Dispose();
            invDialog = null;
        }
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldForResolving)
    {
        base.FromTreeAttributes(tree, worldForResolving);
        Sealed = tree.GetBool("sealed");
        ICoreAPI api = Api;
        if (api != null && api.Side == EnumAppSide.Client)
        {
            //currentMesh = GenMesh();
            //MarkDirty(redrawOnClient: true);
            invDialog?.UpdateContents();
        }

        SealedSinceTotalHours = tree.GetDouble("sealedSinceTotalHours");
        if (Api != null)
        {
            //FindMatchingRecipe();
        }
    }

    public override void OnBlockUnloaded()
    {
        base.OnBlockUnloaded();
        invDialog?.Dispose();
    }
}
