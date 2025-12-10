using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Items;

public class QuestItem : IItem
{
    private IItemCore _core;
    private bool _questCompleted = false;

    public int Health => 0;
    public int Power => _core.Power;

    public QuestItem(IItemCore core)
    {
        _core = core;
    }

    public void CheckQuesComplited(IPlayer player)
    {
        if (player.QuestCompleted)
            _questCompleted = true;
    }

     public void IncreaseHealth(int health)
    {
        _core.IncreaseHealth(health);
    }

    public void IncreasePower(int power)
    {
        _core.IncreasePower(power);
    }

    public void DecreaseHealth(int health)
    {
        _core.DecreaseHealth(health);
    }

    public void DecreasePower(int power)
    {
        _core.DecreasePower(power);
    }

    public bool TryApply(IImproving player)
    {      
        if (!_questCompleted)
            return false;
        return _core.State.TryEquip(_core, player);
    }

    public bool TryUnApply(IImproving player)
    {
        return _core.State.TryUnEquip(_core, player);
    }
   
}