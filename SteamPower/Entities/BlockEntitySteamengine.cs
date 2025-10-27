
using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

using Vintagestory.API.Config;
using Vintagestory.API.Server;

using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using Vintagestory.API.Datastructures;






using Vintagestory.GameContent;
using System.Threading;



namespace SteamPower
{
    internal class BlockEntitySteamengine : BlockEntityContainer
    {
        public override InventoryBase Inventory => new InventoryStoneCoffin(2, null, null);

        public override string InventoryClassName => "stonecoffin";

        public override void OnBlockPlaced(ItemStack byItemStack = null)
        {

        }
        public bool Interact(IPlayer byPlayer, bool preferThis)
        {

            MultiblockStructure ms = Block.Attributes["multiblockStructure"].AsObject<MultiblockStructure>();
            ms.InitForUse(0);
            ms.HighlightIncompleteParts(Api.World, byPlayer, Pos);
            (Api as ICoreClientAPI).SendChatMessage("STEAMPOWER: steamengine entity interacted with");
            return true;
        }
    }
}
