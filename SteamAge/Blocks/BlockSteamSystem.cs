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
    /// Searches the system for the BlockEntity. Will create a BlockEntity if none were found. Will create a BEComponent if none were found.
    /// </summary>
    /// <returns>The found or created BEComponent</returns>
    public static T FindOrCreate<T>(IWorldAccessor world, BlockPos pos) where T : BEComponent, new()
    {
        var blockEntity = Find(world, pos, e => e.HasComponent<T>());

        if (blockEntity == null)
        {
            world.BlockAccessor.SpawnBlockEntity(BESteamSystem.Name, pos);
            blockEntity = world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos);
        }

        var component = blockEntity.GetComponent<T>();
        if (component == null)
        {
            component = blockEntity.AddComponent<T>();
        }

        return component;
    }

    /// <summary>
    /// Searches the system for the BlockEntity
    /// </summary>
    /// <param name="world">World for resolve</param>
    /// <param name="pos">Position to start searching from</param>
    /// <param name="matcher">Function to rule out unimportant BlockEntities</param>
    /// <returns>The first BlockEntity that suffices the matcher</returns>
    public static BESteamSystem Find(IWorldAccessor world, BlockPos pos, Func<BESteamSystem, bool> matcher)
    {
        return world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos); // <- not final just for testing
    }

    /// <summary>
    /// Searches the system for its BlockEntity and returns the given BEComponent
    /// </summary>
    public static T Get<T>(IWorldAccessor world, BlockPos pos) where T : BEComponent
    {
        return Find(world, pos, e => e.HasComponent<T>()).GetComponent<T>();
    }
}
