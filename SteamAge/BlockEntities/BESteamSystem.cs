using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

using System;
using System.Collections;

using SteamAge.BEBehaviors;

namespace SteamAge.BlockEntities;

[Flags]
public enum ComponentFlag : byte
{
    None = 0,
    SteamContainer = 1 << 0,
    SteamGenerator = 1 << 1,
    SteamConsumer = 1 << 2,
    HeatGenerator = 1 << 3,
    All = (1 << 4) - 1
}

/// <summary>
/// This class holds all BEBehaviors in the current system
/// </summary>
public class BESteamSystem : BlockEntity, IRegister
{
    public static string Name => "steamsystem";
    public BitArray ComponentMask = new(8, false);

    public override void Initialize(ICoreAPI api)
    {
        base.Initialize(api);
    }
    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
    {
        base.FromTreeAttributes(tree, worldAccessForResolve);
        ComponentMask = new(tree.GetBytes("mask", new byte[1] { 0 }));
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
        try
        {
            base.ToTreeAttributes(tree);
            byte[] bytes = new byte[1];
            ComponentMask.CopyTo(bytes, 0);
            tree.SetBytes("mask", bytes);
        }
        catch (System.Exception)
        {
            Api.Logger.Chat("Failed to safe");
        }
    }

    public override void CreateBehaviors(Block block, IWorldAccessor worldForResolve)
    {
        Api.Logger.Chat(ComponentMask.HasAnySet().ToString());
        base.CreateBehaviors(block, worldForResolve);

        if (ComponentMask[0]) AddBehavior<BEBehaviorSteamContainer>(worldForResolve);
        if (ComponentMask[1]) AddBehavior<BEBehaviorSteamGenerator>(worldForResolve);
        if (ComponentMask[2]) AddBehavior<BEBehaviorSteamConsumer>(worldForResolve);
        if (ComponentMask[3]) AddBehavior<BEBehaviorHeatGenerator>(worldForResolve);
    }

    /// <summary>
    /// Adds BEBehavior to the behavior lists
    /// </summary>
    /// <remarks>
    /// Updates ComponentMask and calls MarkDirty
    /// </remarks>
    public T AddBehavior<T>(IWorldAccessor world) where T : BlockEntityBehavior, IRegister
    {
        T behavior = world.ClassRegistry.CreateBlockEntityBehavior(this, T.Name) as T;
        Behaviors.Add(behavior);
        ComponentMask.Set(TypeToIndex<T>(), true);
        MarkDirty();
        return behavior;
    }

    /// <summary>
    /// Converts BEBehavior to corresponding index in BitArray
    /// </summary>
    /// <exception cref="ArgumentException">When BEBehavior is not supported</exception>
    private int TypeToIndex<T>() where T : BlockEntityBehavior
    {
        if (typeof(T) == typeof(BEBehaviorSteamContainer)) return 0;
        if (typeof(T) == typeof(BEBehaviorSteamGenerator)) return 1;
        if (typeof(T) == typeof(BEBehaviorSteamConsumer)) return 2;
        if (typeof(T) == typeof(BEBehaviorHeatGenerator)) return 3;
        throw new System.ArgumentException(typeof(T).ToString() + " is not supported.");
    }
}
