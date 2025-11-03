using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

public class HeatGenerator : BEComponent
{
    public override bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
        return false;
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
    }
}
