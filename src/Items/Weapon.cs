using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class Weapon : IItem
{
    private IItemCore _core;
    
    public int Health => _core.Health;
    public int Power => _core.Power;

    public Weapon(IItemCore core)
    {
       _core = core;  
    }

    public void IncreaseHealth(int health)
    {
        _core.IncreaseHealth(health);
    }

    public void IncreasePower(int power)
    {
        _core.IncreasePower(power);
    }

    public void DecreaseHealth(int health)
    {
        _core.DecreaseHealth(health);
    }

    public void DecreasePower(int power)
    {
        _core.DecreasePower(power);
    }

    public bool TryApply(IImproving player)
    {       
        return _core.State.TryEquip(_core, player);
    }

    public bool TryUnApply(IImproving player)
    {
        return _core.State.TryUnEquip(_core, player);
    }
    
}