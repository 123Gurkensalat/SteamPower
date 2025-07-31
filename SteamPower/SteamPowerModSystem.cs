using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace ModTemplate
{
    public class ModTemplateModSystem : ModSystem
    {
        // Called on server and client
        public override void Start(ICoreAPI api)
        {
            api.Logger.Notification("STEAMPOWER: starting mod" + Lang.Get("steampower:hello"));
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
