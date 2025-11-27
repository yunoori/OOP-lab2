using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class QuestItem : IItem
{
    private IItemState _state = new UnEquippedItemState();

    private bool _questCompleted = false;

    public int Power { get; private set; }
    
    public int Health { get; private set; }

    public QuestItem(int power, int health)
    {
        if(power < 0) throw new ArgumentException("negative power given");
        if(health < 0) throw new ArgumentException("negative health given");

        Power = power;
        Health = health;
    }

    public bool CanEquip()
    {
        return _state.CanEquip();
    }

    public void CheckQuesComplited(IPlayer player)
    {
        if (player.QuestCompleted)
            _questCompleted = true;
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
        if (!_questCompleted)
            throw new InvalidOperationException("You didn't complete the quest");

        if(!CanEquip())
            throw new InvalidOperationException("Item is already Equiped");
            
        player.IncreaseHealth(Health);
        player.IncreasePower(Power);
    }
}