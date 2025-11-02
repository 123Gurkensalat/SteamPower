using Vintagestory.API.Common;

namespace SteamAge.BEBehaviors;

public class BEBehaviorSteamConsumer : BlockEntityBehavior, IRegister
{
    public static string Name => "esteamconsumer";
    BEBehaviorSteamConsumer(BlockEntity entity) : base(entity) { }
}
