using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

public class SteamGenerator : BEComponent
{
    public float Water;
    public float Capacity;

    public override bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
        return tree.HasAttribute("water") && tree.HasAttribute("capacity");
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
    {
        Water = tree.GetFloat("water");
        Capacity = tree.GetFloat("capacity");
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
        tree.SetFloat("water", Water);
        tree.SetFloat("capacity", Capacity);
        blockEntity.Api.Logger.Chat("saving...");
    }
}

