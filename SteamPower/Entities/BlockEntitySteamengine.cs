
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
    internal class BlockEntitySteamengine : BlockEntity
    {
        public override void OnBlockPlaced(ItemStack byItemStack = null)
        {
            Thread.Sleep(1500);
            (Api as ICoreClientAPI).SendChatMessage("STEAMPOWER: steamengine entity placed");
        }
    }
}