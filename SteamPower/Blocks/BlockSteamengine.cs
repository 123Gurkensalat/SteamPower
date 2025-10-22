
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

using Vintagestory.GameContent;

namespace SteamPower
{
    internal class BlockSteamengine : Block
    {


        public override bool DoPlaceBlock(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel, ItemStack byItemStack)
        {

            (api as ICoreClientAPI).SendChatMessage("STEAMPOWER: steamengine placed");
        bool flag = true;
        bool flag2 = false;
        BlockBehavior[] blockBehaviors = BlockBehaviors;
        foreach (BlockBehavior obj in blockBehaviors)
        {
            EnumHandling handling = EnumHandling.PassThrough;
            bool flag3 = obj.DoPlaceBlock(world, byPlayer, blockSel, byItemStack, ref handling);
            if (handling != EnumHandling.PassThrough)
            {
                flag = flag && flag3;
                flag2 = true;
            }

            if (handling == EnumHandling.PreventSubsequent)
            {
                return flag;
            }
        }

        if (flag2)
        {
            return flag;
        }

        world.BlockAccessor.SetBlock(BlockId, blockSel.Position, byItemStack);
        return true;


            //this.DoPlaceBlock(world, byPlayer, blockSel, byItemStack);
            //return true;
        }
    }
}