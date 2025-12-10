using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class UnEquippedItemState : IItemState
{
    public bool TryEquip(IItemCore core, IImproving player)
    {
        core.Equip(player);
        core.UpdateState(new EquippedItemState());

        return true;
    }

    public bool TryUnEquip(IItemCore core, IImproving player) => false;
}