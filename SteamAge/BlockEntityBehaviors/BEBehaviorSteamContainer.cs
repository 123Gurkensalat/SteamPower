using Vintagestory.API.Common;

namespace SteamAge.BEBehaviors;

public class BEBehaviorSteamContainer : BlockEntityBehavior, IRegister
{
    public static string Name => "esteamcontainer";
    public Gas Steam = new Gas();
    public Gas Air = new Gas();
    public BEBehaviorSteamContainer(BlockEntity blockEntity) : base(blockEntity)
    {

    }
}
