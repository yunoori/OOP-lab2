namespace InventoryManagementSystem.src.Interfaces;

public interface IItem : IImproving
{
    public bool CanEquip();

    public int Power { get; }

    public int Health { get; }

    void UpdateState(IItemState state);
        
    public void Apply(IImproving player);

}