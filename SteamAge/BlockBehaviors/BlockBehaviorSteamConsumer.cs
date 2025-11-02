using Vintagestory.API.Common;

using SteamAge.Blocks;
using SteamAge.BEBehaviors;
using Vintagestory.API.MathTools;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamConsumer : BlockBehavior, IRegister
{
    public static string Name => "steamconsumer";
    private BlockSteamSystem system => block as BlockSteamSystem;

    public BlockBehaviorSteamConsumer(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling)
    {
        base.OnBlockPlaced(world, blockPos, ref handling);
        system.FindOrCreate<BEBehaviorSteamConsumer>(world, blockPos);
    }
}
