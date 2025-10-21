using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

using SteamAge.Power.Blocks;
using SteamAge.Power.BlockEntities;

namespace SteamAge;

public class SteamAgeModSystem : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        api.Logger.Notification("SteamAge: starting mod...");
        api.RegisterBlockClass(Mod.Info.ModID + ".blocksteampot", typeof(BlockSteampot));
        api.RegisterBlockEntityClass(Mod.Info.ModID + ".steampot", typeof(BlockEntitySteampot));
        api.Logger.Notification("SteamAge: mod has started");
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
