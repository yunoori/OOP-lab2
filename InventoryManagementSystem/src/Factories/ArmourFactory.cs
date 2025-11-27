using InventoryManagementSystem.src.Interfaces;
using InventoryManagementSystem.src.Items;

namespace InventoryManagementSystem.src.Factories;

public class ArmourFactory : IItemFactory
{
    private int _health;

    public ArmourFactory(int health)
    {
        _health = health;
    }

    public IItem Create()
    {
        return new Armour(_health);
    }
}