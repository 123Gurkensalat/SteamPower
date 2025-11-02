using Vintagestory.API.Common;

namespace SteamAge.BlockEntities;

public class BEBehaviorHeatGenerator : BlockEntityBehavior, IRegister
{
    public static string Name => "eheatgenerator";
    public BEBehaviorHeatGenerator(BlockEntity entity) : base(entity) { }
}
