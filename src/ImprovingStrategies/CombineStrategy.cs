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
        bool result = _itemToCombineWith.TryApply(item);

        if (!result)
            throw new InvalidOperationException("Can't apply this Item");

        return item;
    }
}