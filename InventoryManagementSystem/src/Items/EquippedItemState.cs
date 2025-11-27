using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class EquippedItemState : IItemState
{
    public bool CanEquip() => false;

    public bool CanUnEquip() => true;
}