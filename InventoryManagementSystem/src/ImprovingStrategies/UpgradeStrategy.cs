using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.ImprovingStrategies;

public class UpgradeStrategy : IImproveStrategy
{
    private int _healthUpValue;
    private int _powerUpValue;

    public UpgradeStrategy(int healthUpValue, int powerUpValue)
    {
        _healthUpValue = healthUpValue;
        _powerUpValue = powerUpValue;
    }

    public IItem Improve(IItem item)
    {
        item.IncreaseHealth(_healthUpValue);
        item.IncreasePower(_powerUpValue);

        return item;
    }
}

