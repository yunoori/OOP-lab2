using InventoryManagementSystem.src.Interfaces;
using InventoryManagementSystem.src.Items;

namespace InventoryManagementSystem.src.Game;

public class Player : IPlayer
{
    private List<IItem> Items { get; } = [];

    public int Power { get; private set; }

    public int Health { get; private set; }

    public string Name { get; }

    public bool QuestCompleted { get; private set; }

    public Player(string name, int power, int health)
    {
        Name = name;
        Power = power;
        Health = health;
    }

    public void AddNewItem(IItem item)
    {
        Items.Add(item);
    }
    
    public bool TryEquipNewItem(IItem item)
    {
        return item.TryApply(this);
    }

    public bool TryUnEquipNewItem(IItem item)
    {
        return item.TryUnApply(this);
    }

    public void CompleteQuest()
    {
        QuestCompleted = true;
    }

    public List<IItem> GetInventory()
    {
        return Items;
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