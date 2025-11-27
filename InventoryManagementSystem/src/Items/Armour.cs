using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class Armour : IItem
{
    private IItemState _state = new UnEquippedItemState();
    
    public int Health { get; private set; }
    public int Power { get; private set; } = 0;

    public Armour(int health)
    {
       if(health < 0) throw new ArgumentException("negative health given");
        Health = health;
    }

    public bool CanEquip()
    {
        return _state.CanEquip();
    }

    public void UpdateState(IItemState state)
    {
        _state = state;
    }

    public void IncreaseHealth(int health)
    {
        Health += health; 
    }

    public void IncreasePower(int power)
    {
        Power += power;
    }


    public void Apply(IImproving player)
    {
        if(!CanEquip())
            throw new InvalidOperationException("Item is already Equiped");
            
        player.IncreaseHealth(Health);
        player.IncreasePower(Power);
    }
    
}