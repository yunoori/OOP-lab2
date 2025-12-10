using InventoryManagementSystem.src.Interfaces;
using InventoryManagementSystem.src.Items;

namespace InventoryManagementSystem.src.Factories;


public class PotionFactory : IItemFactory
{
    private int _power;
    private int _health;

    public PotionFactory(int power, int health)
    {
        _power = power;
        _health = health;
    }

    public IItem Create()
    {
        var core = new ItemCore(_power, _health);
        return new Potion(core);
    }
}