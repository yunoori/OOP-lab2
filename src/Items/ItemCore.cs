using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class ItemCore : IItemCore
{
    public ItemCore(int power, int health)
    {
        if (power < 0) throw new ArgumentException("negative power");
        if (health < 0) throw new ArgumentException("negative health");

        Power = power;
        Health = health;
        State = new UnEquippedItemState();
    }

    public IItemState State { get; private set;} 

    public int Power { get; private set; }
    
    public int Health { get; private set; }

    public void Equip(IImproving player)
    {
        player.IncreaseHealth(Health);
        player.IncreasePower(Power);
    }

    public void UnEquip(IImproving player)
    {
        player.DecreaseHealth(Health);
        player.DecreasePower(Power);
    }

    public void UpdateState(IItemState state)
    {
        State = state;
    }

    public void IncreaseHealth(int health)
    {
        Health += health; 
    }

    public void IncreasePower(int power)
    {
        Power += power;
    }

    public void DecreaseHealth(int health)
    {
        Health -= health; 
    }

    public void DecreasePower(int power)
    {
        Power -= power;
    }
}