
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;


namespace SteamPower.Blocks
{

    internal class BlockSteampot : Block
    {



        //Any code within this 'override' function will be called when a trampoline block is placed. 
        public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ItemStack byItemStack = null)
        {
            api.Logger.Chat("Steam Pot Block Placed!");
            //Log a message to the console.
            api.Logger.Notification("Steam Pot Block Placed!");
            //Perform any default logic when our block is placed.
            base.OnBlockPlaced(world, blockPos, byItemStack);
        }
    }
}

