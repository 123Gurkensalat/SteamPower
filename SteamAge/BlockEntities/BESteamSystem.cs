using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

using System;
using System.Collections.Generic;

namespace SteamAge.BlockEntities;

/// <summary>
/// This class holds all BEComponents in the current system
/// </summary>
public class BESteamSystem : BlockEntity, IRegister
{
    public static string Name => "steamsystem";

    Dictionary<Type, BEComponent> components = new();

    public override void Initialize(ICoreAPI api)
    {
        base.Initialize(api);
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
    {
        base.FromTreeAttributes(tree, worldAccessForResolve);

        TryAddComponentFromTreeAttributes<SteamGenerator>(tree, worldAccessForResolve);
        TryAddComponentFromTreeAttributes<SteamContainer>(tree, worldAccessForResolve);
        TryAddComponentFromTreeAttributes<SteamConsumer>(tree, worldAccessForResolve);
        TryAddComponentFromTreeAttributes<HeatGenerator>(tree, worldAccessForResolve);

        foreach (var (_, component) in components)
        {
            component.FromTreeAttributes(tree, worldAccessForResolve);
        }
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
        Api?.Logger.Chat(GetComponent<SteamGenerator>().Water.ToString());
        base.ToTreeAttributes(tree);
        foreach (var (_, component) in components)
        {
            component.ToTreeAttributes(tree);
        }
    }

    /// <summary>
    /// Adds the given component. If component == null, the default constructor gets called
    /// </summary>
    public T AddComponent<T>(T component = null) where T : BEComponent, new()
    {
        component ??= new T();
        component.blockEntity = this;
        components.Add(typeof(T), component);
        return component;
    }

    /// <summary>
    /// Adds given component when the BlockEntity has the needed attributes
    /// </summary>
    public void TryAddComponentFromTreeAttributes<T>(ITreeAttribute tree, IWorldAccessor worldAccessForResolve) where T : BEComponent, new()
    {
        T component = new T();
        if (component.HasTreeAttributes(tree, worldAccessForResolve))
        {
            AddComponent<T>(component);
        }
    }

    /// <summary>
    /// Returns if this BlockEntity has given component
    /// </summary>
    public bool HasComponent<T>() where T : BEComponent
    {
        return components.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Returns the given component. If not found will return null;
    /// </summary>
    public T GetComponent<T>() where T : BEComponent
    {
        return components.TryGetValue(typeof(T)) as T;
    }
}
