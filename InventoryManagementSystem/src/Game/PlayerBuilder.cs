using InventoryManagementSystem.src.Interfaces;

namespace InventoryManagementSystem.src.Game;

public class PlayerBuilder : IPlayerBuilder
{
    private readonly int _health;
    private readonly int _power;
    private readonly string _name;
    private readonly List<IItem> _items = [];

    public PlayerBuilder(string name, int health, int power)
    {
        _health = health;
        _power = power;
        _name = name;
    }

    public IPlayerBuilder WithItem(IItem item)
    {
        _items.Add(item);

        return this;
    }

    public IPlayer Build()
    {
        var player = new Player(_name, _power, _health);

        foreach (var item in _items)
        {
            player.AddNewItem(item);
            player.TryEquipNewItem(item);
        }

        return player;
    }
}