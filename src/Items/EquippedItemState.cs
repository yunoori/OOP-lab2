using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class EquippedItemState : IItemState
{
    public bool TryEquip(IItemCore core, IImproving improving) => false;

    public bool TryUnEquip(IItemCore core, IImproving player)
    {
        core.UnEquip(player);

        core.UpdateState(new UnEquippedItemState());

        return true;
    }
}