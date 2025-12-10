namespace InventoryManagementSystem.src.Interfaces;

public interface ISystem
{
    void AddItem(IPlayer player, IItem item);

    bool TryEquipItem(IPlayer player, IItem item);

    List<IItem> GetPlayerInventory(IPlayer player);

    void ImproveItem(IItem item);

    void ChangeImproveStrategy(IImproveStrategy strategy);
}