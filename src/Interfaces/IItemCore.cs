namespace InventoryManagementSystem.src.Interfaces;

public interface IItemCore : IImproving
{
    IItemState State { get; }

    int Power { get; }
    
    int Health { get; }

    void Equip(IImproving player);

    void UnEquip(IImproving player);

    void UpdateState(IItemState state);
}