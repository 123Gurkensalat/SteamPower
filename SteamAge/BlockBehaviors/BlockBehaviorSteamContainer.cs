using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

using SteamAge.Blocks;
using SteamAge.BlockEntities;

namespace SteamAge.BlockBehaviors;

public class BlockBehaviorSteamContainer : BlockBehavior, IRegister
{
    public static string Name => "steamcontainer";
    public BlockBehaviorSteamContainer(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling)
    {
        base.OnBlockPlaced(world, blockPos, ref handling);
        BlockSteamSystem.FindOrCreate<SteamContainer>(world, blockPos);
    }
}
