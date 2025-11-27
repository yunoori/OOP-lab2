using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class UnEquippedItemState : IItemState
{
    public bool CanEquip() => true;

    public bool CanUnEquip() => false;
}