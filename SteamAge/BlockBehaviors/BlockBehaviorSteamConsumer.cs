using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

using SteamAge.Blocks;
using SteamAge.BlockEntities;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamConsumer : BlockBehavior, IRegister
{
    public static string Name => "steamconsumer";

    public BlockBehaviorSteamConsumer(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling)
    {
        base.OnBlockPlaced(world, blockPos, ref handling);
        BlockSteamSystem.FindOrCreate<SteamConsumer>(world, blockPos);
    }
}
