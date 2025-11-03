using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

public abstract class BEComponent
{
    public BESteamSystem blockEntity;

    private ICoreAPI Api => blockEntity.Api;
    private IWorldAccessor World => blockEntity.Api.World;

    public abstract bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world);

    public abstract void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor world);

    public abstract void ToTreeAttributes(ITreeAttribute tree);
}
