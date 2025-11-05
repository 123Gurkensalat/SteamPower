using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

/// <summary>
/// Base class that allows inherited classes to be added to the BESteamSystem
/// </summary>
public abstract class BEComponent
{
    public BESteamSystem blockEntity;

    private ICoreAPI Api => blockEntity.Api;
    private IWorldAccessor World => blockEntity.Api.World;

    public abstract bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world);

    public abstract void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor world);

    public abstract void ToTreeAttributes(ITreeAttribute tree);
}
