using Vintagestory.API.Common;

using SteamAge.Blocks;
using SteamAge.BEBehaviors;
using Vintagestory.API.MathTools;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamConsumer : BlockBehavior, IRegister
{
    public static string Name => "steamconsumer";

    public BlockBehaviorSteamConsumer(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling)
    {
        base.OnBlockPlaced(world, blockPos, ref handling);
        BlockSteamSystem.FindOrCreate<BEBehaviorSteamConsumer>(world, blockPos);
    }
}
