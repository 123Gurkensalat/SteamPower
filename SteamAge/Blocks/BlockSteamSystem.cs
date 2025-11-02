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
    public static T FindOrCreate<T>(IWorldAccessor world, BlockPos pos) where T : BlockEntityBehavior, IRegister
    {
        var blockEntity = Find(world, pos);

        if (blockEntity == null)
        {
            world.BlockAccessor.SpawnBlockEntity(BESteamSystem.Name, pos);
            blockEntity = world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos);
        }

        var behavior = blockEntity.GetBehavior<T>();
        if (behavior == null)
        {
            behavior = blockEntity.AddBehavior<T>(world);
        }

        return behavior;
    }

    /// <summary>
    /// Searches the system for the BlockEntity
    /// </summary>
    public static BESteamSystem Find(IWorldAccessor world, BlockPos pos)
    {
        return world.BlockAccessor.GetBlockEntity<BESteamSystem>(pos); // <- not final just for testing
    }

    /// <summary>
    /// Searches the system for its BlockEntity and returns the given BEBehavior
    /// </summary>
    public static T Get<T>(IWorldAccessor world, BlockPos pos) where T : BlockEntityBehavior
    {
        return Find(world, pos)?.GetBehavior<T>();
    }
}
