using Vintagestory.API.Common;

namespace SteamAge.Blocks;

public class BlockBehaviorHeatGenerator : BlockBehavior, IRegister
{
    public static string Name => "heatgenerator";
    public BlockBehaviorHeatGenerator(Block block) : base(block) { }
}
