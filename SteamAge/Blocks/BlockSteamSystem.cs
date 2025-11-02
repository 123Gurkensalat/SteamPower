using Vintagestory.API.Common;

using SteamAge.BlockEntities;

namespace SteamAge.Blocks;

/// <summary>
/// Base block to quickly test if the block is part of a steam system
/// </summary>
/// <remarks>
/// Contains some utility for the BlockBehaviors
/// </remarks>
public class BlockSteamSystem : Block
{
    /// <summary>
    /// Searches the system for the BlockEntity
    /// </summary>
    public BESteamSystem Find(IWorldAccessor world, BlockSelection blockSel)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Searches the system for its BlockEntity and returns the given BEBehavior
    /// </summary>
    public T Get<T>(IWorldAccessor world, BlockSelection blockSel) where T : BlockEntityBehavior
    {
        return Find(world, blockSel).GetBehavior<T>();
    }
}
