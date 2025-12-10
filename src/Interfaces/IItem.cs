namespace InventoryManagementSystem.src.Interfaces;

public interface IItem : IImproving
{
    public int Power { get; }

    public int Health { get; }
        
    public bool TryApply(IImproving player);

    public bool TryUnApply(IImproving player);

}