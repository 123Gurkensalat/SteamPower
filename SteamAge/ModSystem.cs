using SteamAge.BEBehaviors;
using SteamAge.BlockBehaviors;

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
    }

    private void RegisterBlockEntityClasses(ICoreAPI api)
    {
    }

    private void RegisterBlockBehaviorClasses(ICoreAPI api)
    {
        api.RegisterBlockBehaviorClass("steamgenerator", typeof(BlockBehaviorSteamGenerator));
        api.RegisterBlockBehaviorClass("steamcontainer", typeof(BlockBehaviorSteamContainer));
        api.RegisterBlockBehaviorClass("steamconsumer", typeof(BlockBehaviorSteamConsumer));
    }

    private void RegisterBlockEntityBehaviorClasses(ICoreAPI api)
    {
        api.RegisterBlockEntityBehaviorClass("esteamgenerator", typeof(BEBehaviorSteamGenerator));
        api.RegisterBlockEntityBehaviorClass("esteamcontainer", typeof(BEBehaviorSteamContainer));
        api.RegisterBlockEntityBehaviorClass("esteamconsumer", typeof(BEBehaviorSteamConsumer));
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
