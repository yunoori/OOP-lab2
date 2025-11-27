using InventoryManagementSystem.src.Interfaces;
using InventoryManagementSystem.src.Items;

namespace InventoryManagementSystem.src.Game;

public class InventorySystem : ISystem
{
    private IImproveStrategy _improveStrategy;

    public InventorySystem(IImproveStrategy strategy)
    {
        _improveStrategy = strategy;
    }

    public void AddItem(IPlayer player, IItem item)
    {
        player.AddNewItem(item);
    }

    public bool TryEquipItem(IPlayer player, IItem item)
    {
        return player.TryEquipNewItem(item);
    }

    public List<IItem> GetPlayerInventory(IPlayer player)
    {
        return player.GetInventory();
    }

    public void ImproveItem(IItem item)
    {
        _improveStrategy.Improve(item);
    }

    public void ChangeImproveStrategy(IImproveStrategy strategy)
    {
        _improveStrategy = strategy;
    }
}