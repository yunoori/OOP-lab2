using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.ImprovingStrategies;

public class CombineStrategy : IImproveStrategy
{
    private readonly IItem _itemToCombineWith;

    public CombineStrategy(IItem itemToCombineWith)
    {
        _itemToCombineWith = itemToCombineWith;
    }

    public IItem Improve(IItem item)
    {
        _itemToCombineWith.Apply(item);

        return item;
    }
}