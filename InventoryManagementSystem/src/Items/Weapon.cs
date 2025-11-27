using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class Weapon : IItem
{
    private IItemState _state = new UnEquippedItemState();

    public int Power { get; private set; }
    public int Health { get; private set; } = 0;

    public Weapon(int power)
    {
        if(power < 0) throw new ArgumentException("negative power given");

        Power = power;
    }

    public bool CanEquip()
    {
        return _state.CanEquip();
    }

    public void IncreaseHealth(int health)
    {
        Health += health; 
    }

    public void IncreasePower(int power)
    {
        Power += power;
    }

    public void UpdateState(IItemState state)
    {
        _state = state;
    }

    public void Apply (IImproving player)
    {
        if(!CanEquip())
            throw new InvalidOperationException("Item is already Equiped");
        player.IncreaseHealth(Health);
        player.IncreasePower(Power);
    }
}