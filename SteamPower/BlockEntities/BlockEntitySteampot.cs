
using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

using Vintagestory.API.Config;
using Vintagestory.API.Server;

using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;



namespace SteamPower
{
    internal class BlockSteampot : BlockEntity
    {

        BlockEntityFirepit firepit = null;
        // constructor
        // public BlockSteampot() { }

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);


            //Log a message to the server console
            api.Logger.Notification("Steam Pot Block Loaded!");

            //Perform any default logic when our block is placed.

            //
            // BlockPos newFirepitPos =
            // // newFirepitPos.Y--;
            // //
            // BlockEntityFirepit nextFirepit = Block.GetBlockEntity<BlockEntityFirepit>(newFirepitPos);
            // // // if (firepit != nextFirepit)
            // // // {
            // firepit = nextFirepit;
            // api.World.RegisterGameTickListener(Update, 500);
            // // }
        }


        private void Update(float dTime)
        {
            Console.WriteLine("FIREPIT BE HERE");
            if (firepit == null)
                api.Logger.Notification("FIREPIT IS NULL");
            // I think this is a logistic function
            // if (firepit != null && firepit.furnaceTemperature > 800)
            api.Logger.Chat("Current Temperature for steampot fire source: {0}", firepit.furnaceTemperature);

        }




        // public override void OnLoaded(ICoreAPI api)
        // {
        //
        //     //Log a message to the server console
        //     api.Logger.Notification("Steam Pot Block Loaded!");
        //
        //     //Perform any default logic when our block is placed.
        //
        //
        //     BlockEntityFirepit nextFirepit = GetBlockEntity<BlockEntityFirepit>(base. );
        //     if (firepit != nextFirepit)
        //     {
        //         firepit = nextFirepit;
        //         api.World.RegisterGameTickListener(Update, 500);
        //     }
        // }



        // public override void OnUnloaded(ICoreAPI api) { }


        // public override void OnNeighbourBlockChange(IWorldAccessor world, BlockPos pos, BlockPos neibPos)
        // {
        //     base.OnNeighbourBlockChange(world, pos, neibPos);
        //     if (neibPos.Y >= pos.Y) return;
        //     firepit = GetBlockEntity<BlockEntityFirepit>(neibPos);
        //
        //     // if (firepit == null)
        //     //     listenerId = api.World.RegisterGameTickListener(Update, 500);
        //     // else
        //     //     api.World.UnregisterGameTickListener(listenerId);
        // }
        //
        // // BlockPlaceOnDrop
        //
        //
        // public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ItemStack byItemStack = null)
        // {
        //     api.Logger.Chat("Steam Pot Block Placed!");
        //     //Log a message to the console.
        //     api.Logger.Notification("Steam Pot Block Placed!");
        //
        //     //Perform any default logic when our block is placed.
        //     base.OnBlockPlaced(world, blockPos, byItemStack);
        //     BlockPos belowBlockPos = blockPos;
        //     blockPos.Y--;
        //
        //     BlockEntityFirepit nextFirepit = GetBlockEntity<BlockEntityFirepit>(blockPos);
        //     if (firepit != nextFirepit)
        //     {
        //         firepit = nextFirepit;
        //         api.World.RegisterGameTickListener(Update, 500);
        //     }
        // }

    }
}

