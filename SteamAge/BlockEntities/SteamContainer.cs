using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

public class SteamContainer : BEComponent
{
    public Gas Steam = new Gas();
    public Gas Air = new Gas();

    public override bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
        return true;
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
    }
}
