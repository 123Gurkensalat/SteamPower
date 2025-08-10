

using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

using Vintagestory.API.Config;
using Vintagestory.API.Server;

using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using System.Threading;



namespace SteamPower
{
    internal class BlockSteampot : BlockBarrel
    {
        // constructor
        // public BlockSteampot() { }
        //
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            api.Logger.Notification("STEAMPOWER: loaded BlockSteampot");
        }


        // public override void OnNeighbourBlockChange(IWorldAccessor world, BlockPos pos, BlockPos neibpos)
        // {
        //
        //     //INFO: if neibpos isn't exactly below, don't do anything
        //     if (neibpos.Y + 1 != pos.Y)
        //         return;
        //
        //     api.Logger.Notification("STEAMPOWER: pos: [x:{0} y:{1}", pos.X, pos.Y);
        //     api.Logger.Notification("STEAMPOWER: neightpos: [x:{0} y:{1}", neibpos.X, neibpos.Y);
        //
        //     checkForEntity(pos);
        //
        //     BlockPos surveyedPos = pos;
        //     surveyedPos.Y--;
        //     //j
        //     BlockEntity entityBelow = GetBlockEntity<BlockEntityFirepit>(surveyedPos);
        //
        //     // //INFO: set to null in case if firepit is no longer below
        //     // entity.firepit = (entityBelow != null) ? (BlockEntityFirepit)(entityBelow) : null;
        //     // if (entity.firepit != null)
        //     //     api.Logger.Notification("STEAMPOWER: detected firepit block change below steampot");
        // }
        //
        // // INFO: checks if entity of the block is null, if so tries to set it
        // private void checkForEntity(BlockPos pos)
        // {
        //     // if (entity == null)
        //     entity = GetBlockEntity<BlockSteampotEntity>(pos);
        //     pos.Y--;
        //     BlockSteampotEntity entitybelow = GetBlockEntity<BlockSteampotEntity>(pos);
        //     // WARNING: if it still null, prints out Error message
        //     if (entity == null)
        //     {
        //         api.Logger.Warning("STEAMPOWER: FAILED TO FIND THE ENTITY FOR A GIVEN BLOCK pos:[x:{0} y:{1}]", pos.X, pos.Y);
        //
        //         if (entitybelow == null)
        //             api.Logger.Warning("STEAMPOWER: FAILED TO FIND THE ENTITYBELOW FOR A GIVEN BLOCK pos:[x:{0} y:{1}]", pos.X, pos.Y);
        //         else
        //             api.Logger.Warning("STEAMPOWER: FOUND THE ENTITYBELOW FOR A GIVEN BLOCK pos:[x:{0} y:{1}]", pos.X, pos.Y);
        //     }
        //     else
        //         api.Logger.Warning("STEAMPOWER: FOUND THE ENTITY FOR A GIVEN BLOCK pos:[x:{0} y:{1}]", pos.X, pos.Y);
        //
        // }

    }
}

