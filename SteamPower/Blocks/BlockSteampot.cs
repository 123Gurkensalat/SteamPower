
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace SteamPower.Blocks
{
    internal class BlockSteampot : Block
    {
        BlockEntityFirepit firepit;
        float temperature;
        public override void OnNeighbourBlockChange(IWorldAccessor world, BlockPos pos, BlockPos neibPos)
        {
            base.OnNeighbourBlockChange(world, pos, neibPos);
            if (neibPos.Y >= pos.Y) return;
            firepit = GetBlockEntity<BlockEntityFirepit>(neibPos);
            api.World.RegisterGameTickListener(Update, 500);
        }

        public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ItemStack byItemStack = null)
        {
            api.Logger.Chat("Steam Pot Block Placed!");
            //Log a message to the console.
            api.Logger.Notification("Steam Pot Block Placed!");
            //Perform any default logic when our block is placed.
            base.OnBlockPlaced(world, blockPos, byItemStack);
        }

        private void Update(float dTime)
        {
            // I think this is a logistic function
            temperature += dTime + dTime * System.Math.Abs(temperature - firepit.furnaceTemperature);
        }
    }
}

