namespace InventoryManagementSystem.src.Interfaces;

public interface IPlayerBuilder
{
    IPlayerBuilder WithItem(IItem item);

    IPlayer Build();
}