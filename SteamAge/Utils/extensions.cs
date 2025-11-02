using Vintagestory.API.Common;

namespace SteamAge;

public static class Extensions
{
    public static void Register<T>(this ICoreAPI api) where T : IRegister
    {
        if (typeof(T).IsSubclassOf(typeof(Block)))
            api.RegisterBlockClass(T.Name, typeof(T));
        else if (typeof(T).IsSubclassOf(typeof(BlockEntity)))
            api.RegisterBlockEntityClass(T.Name, typeof(T));
        else if (typeof(T).IsSubclassOf(typeof(BlockBehavior)))
            api.RegisterBlockBehaviorClass(T.Name, typeof(T));
        else if (typeof(T).IsSubclassOf(typeof(BlockEntityBehavior)))
            api.RegisterBlockEntityBehaviorClass(T.Name, typeof(T));
        else
            throw new System.InvalidOperationException();
    }
}
