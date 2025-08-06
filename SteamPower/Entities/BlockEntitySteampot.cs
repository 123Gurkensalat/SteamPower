
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
    internal class BlockSteampotEntity : BlockEntity
    {



        public BlockEntityFirepit firepit { get; set; } = null;
        // constructor
        // public BlockSteampot() { }
        //
        public override void Initialize(ICoreAPI api)
        {

            base.Initialize(api);
            api.Logger.Notification("STEAMPOWER: initialised BlockSteampotEntity");

            BlockPos surveyedPos = Pos;

            api.Logger.Notification("STEAMPOWER: Entity declared at: pos: [x:{0} y:{1}]", Pos.X, Pos.Y);


            RegisterGameTickListener(findBelow, 2000);


            // BlockEntity possibleFirepit = Block.GetBlockEntity<BlockEntityFirepit>(surveyedPos);
            // firepit = (BlockEntityFirepit)possibleFirepit;


        }


        public void findBelow(float dt)
        {

            Block fir = Api.World.BlockAccessor.GetBlock(Pos.DownCopy());


            if (fir != null && fir is BlockFirepit)
                Api.Logger.Notification("STEAMPOWER: Fireplace DOES Exists Below BlockSteampotEntity [{0}]. temp: {1}", this.Block.BlockId, 0);
            else
                Api.Logger.Notification("STEAMPOWER: Fireplace DOES NOT exist Below BlockSteampotEntity [{0}]", this.Block.BlockId);

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

