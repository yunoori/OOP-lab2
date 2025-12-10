namespace InventoryManagementSystem.src.Interfaces;

public interface IItemState
{
    bool TryEquip(IItemCore core, IImproving player);

    bool TryUnEquip(IItemCore core, IImproving player);
}