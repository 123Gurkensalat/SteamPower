using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

using SteamAge.BlockEntities;

namespace SteamAge.Blocks;

/// <summary>
/// Base block to quickly test if the block is part of a steam system
/// </summary>
/// <remarks>
/// Contains some utility for the BlockBehaviors
/// </remarks>
public class BlockSteamSystem : Block, IRegister
{
    public static string Name => "steamsystem";

    /// <summary>
    /// Searches the system for the BlockEntity. Will create a BlockEntity if none were found. Will create a BEBehavior if none were found.
    /// </summary>
    /// <returns>The found or created BEBehavior</returns>
    public T FindOrCreate<T>(IWorldAccessor world, BlockPos pos) where T : BlockEntityBehavior, IRegister
    {
        var blockEntity = Find(world, pos);

        // If first block of system create block entity
        if (blockEntity == null)
        {
            world.BlockAccessor.SpawnBlockEntity(BESteamSystem.Name, pos);
            blockEntity = world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos);
        }

        var behavior = blockEntity.GetBehavior<T>();
        if (behavior == null)
        {
            // add behavior to blockEntity
            behavior = world.ClassRegistry.CreateBlockEntityBehavior(blockEntity, T.Name) as T;
            blockEntity.Behaviors.Add(behavior);
        }

        return behavior;
    }

    /// <summary>
    /// Searches the system for the BlockEntity
    /// </summary>
    public BESteamSystem Find(IWorldAccessor world, BlockPos pos)
    {
        return world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos); // <- not final just for testing
    }

    /// <summary>
    /// Searches the system for its BlockEntity and returns the given BEBehavior
    /// </summary>
    public T Get<T>(IWorldAccessor world, BlockPos pos) where T : BlockEntityBehavior
    {
        return Find(world, pos)?.GetBehavior<T>();
    }
}
