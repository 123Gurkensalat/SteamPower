using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BEBehaviors;

public class BEBehaviorSteamGenerator : BlockEntityBehavior, IRegister
{
    public static string Name => "esteamgenerator";
    public float Water = 0f;
    public float Capacity = 0f;

    public BEBehaviorSteamGenerator(BlockEntity blockEntity) : base(blockEntity) { }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
    {
        base.FromTreeAttributes(tree, worldAccessForResolve);
        Water = tree.GetFloat("water", 0f);
        Capacity = tree.GetFloat("capacity", 0f);
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
        base.ToTreeAttributes(tree);
        tree.SetFloat("water", Water);
        tree.SetFloat("capacity", Capacity);
    }
}

