using InventoryManagementSystem.src.Interfaces;
using InventoryManagementSystem.src.Items;

namespace InventoryManagementSystem.src.Factories;

public class WeaponFactory : IItemFactory
{
    private int _power;

    public WeaponFactory(int power)
    {
        _power = power;
    }

    public IItem Create()
    {
        var core = new ItemCore(_power, 0);
        return new Weapon(core);
    }
}