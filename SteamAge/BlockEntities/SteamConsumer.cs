using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace SteamAge.BlockEntities;

public class SteamConsumer : BEComponent
{
    SteamContainer container;

    float accumulator; // current pressure in [-capacity, capacity]
    float capacity; // pressure needed for tick

    public delegate void OnTickHandler();
    public event OnTickHandler OnTick;

    public void Init(SteamContainer container)
    {
        this.container = container;
        blockEntity.RegisterGameTickListener(OnGameTick, 100, 0);
    }

    public void Subscribe(OnTickHandler func, float cost)
    {
        capacity += cost;
        OnTick += func;
    }

    private void OnGameTick(float dTime)
    {
        if (capacity <= 0) return;

        // update accumulator
        if (container.Steam.Pressure > 1)
        {
            accumulator += 1;
        }

        // consume accumulator
        while (accumulator > capacity)
        {
            accumulator -= capacity;
            OnTick?.Invoke();
        }
    }

    public override bool HasTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
        return false;
    }

    public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor world)
    {
    }

    public override void ToTreeAttributes(ITreeAttribute tree)
    {
    }
}
