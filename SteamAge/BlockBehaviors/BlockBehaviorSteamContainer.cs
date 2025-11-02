using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

using SteamAge.Blocks;
using SteamAge.BEBehaviors;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamContainer : BlockBehavior, IRegister
{
    public static string Name => "steamcontainer";
    private BlockSteamSystem system => block as BlockSteamSystem;
    public BlockBehaviorSteamContainer(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling)
    {
        base.OnBlockPlaced(world, blockPos, ref handling);
        system.FindOrCreate<BEBehaviorSteamContainer>(world, blockPos);
    }
}
