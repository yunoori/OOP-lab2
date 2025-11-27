namespace InventoryManagementSystem.src.Interfaces;

public interface IItemState
{
    bool CanEquip();

    bool CanUnEquip();
}