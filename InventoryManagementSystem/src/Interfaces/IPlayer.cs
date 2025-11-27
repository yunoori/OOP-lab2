namespace InventoryManagementSystem.src.Interfaces;

public interface IPlayer : IImproving
{
    void AddNewItem(IItem item);

    List<IItem> GetInventory();

    bool TryEquipNewItem(IItem item);

    public void CompleteQuest();

    public int Health { get; }

    public int Power { get; }

    public bool QuestCompleted { get; }
}