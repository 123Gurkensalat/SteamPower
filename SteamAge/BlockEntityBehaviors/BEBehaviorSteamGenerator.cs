using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BEBehaviors;

public class BEBehaviorSteamGenerator : BlockEntityBehavior
{
    public float Water = 0f;

    public BEBehaviorSteamGenerator(BlockEntity blockEntity) : base(blockEntity) { }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
    {
        base.FromTreeAttributes(tree, worldAccessForResolve);
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
        base.ToTreeAttributes(tree);
    }
}

