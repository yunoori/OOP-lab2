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
        return new Weapon(_power);
    }
}