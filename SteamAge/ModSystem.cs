using SteamAge.BlockBehaviors;
using SteamAge.Blocks;
using SteamAge.BlockEntities;

using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace SteamAge;

public class SteamAgeModSystem : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        api.Logger.Notification("SteamAge: starting mod...");
        RegisterBlockClasses(api);
        RegisterBlockBehaviorClasses(api);
        RegisterBlockEntityClasses(api);
        RegisterBlockEntityBehaviorClasses(api);
        api.Logger.Notification("SteamAge: mod has started");
    }

    private void RegisterBlockClasses(ICoreAPI api)
    {
        api.Register<BlockSteamSystem>();
    }

    private void RegisterBlockEntityClasses(ICoreAPI api)
    {
        api.Register<BESteamSystem>();
    }

    private void RegisterBlockBehaviorClasses(ICoreAPI api)
    {
        api.Register<BlockBehaviorSteamGenerator>();
        api.Register<BlockBehaviorSteamContainer>();
        api.Register<BlockBehaviorSteamConsumer>();
        api.Register<BlockBehaviorHeatGenerator>();
    }

    private void RegisterBlockEntityBehaviorClasses(ICoreAPI api)
    {
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        api.Logger.Notification("SteamAge: server side has started");
    }

    public override void StartClientSide(ICoreClientAPI api)
    {
        api.ShowChatMessage("SteamAge: client side has started");
    }
}
