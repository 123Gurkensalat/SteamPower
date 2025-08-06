using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.API.MathTools;


namespace SteamPower
{
    public class ModTemplateModSystem : ModSystem
    {
        // Called on server and client
        public override void Start(ICoreAPI api)
        {
            api.Logger.Notification("STEAMPOWER: starting mod..." + Lang.Get("steampower:hello"));
            api.RegisterBlockClass(Mod.Info.ModID + ".blocksteampot", typeof(BlockSteampot));
            api.RegisterBlockEntityClass(Mod.Info.ModID + ".steampot", typeof(BlockSteampotEntity));
            api.Logger.Notification("STEAMPOWER: mod has started" + Lang.Get("steampower:hello"));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.Logger.Notification("STEAMPOWER: server side has started");
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            api.ShowChatMessage("STEAMPOWER: client side has started");
        }

    }
}
