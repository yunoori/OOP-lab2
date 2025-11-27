using InventoryManagementSystem.src.Factories;
using InventoryManagementSystem.src.Game;
using InventoryManagementSystem.src.ImprovingStrategies;
using InventoryManagementSystem.src.Items;
using Xunit;

namespace InventoryManagementSystem.Tests;

public class InventorySystemTests
{
    [Fact]
    public void AddItemTest()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(3, 3);
        var system = new InventorySystem(improveStrategy);
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();

        // Act
        system.AddItem(playerBob, weapon);
        
        // Assert
        Assert.Single(system.GetPlayerInventory(playerBob));
    }

    [Fact]
    public void UpgradeItemTest()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(0, 3);
        var system = new InventorySystem(improveStrategy);
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        system.AddItem(playerBob, weapon);

        // Act

        system.ImproveItem(weapon);

        // Assert
        Assert.Equal(7, weapon.Power);
    }

    [Fact]
    public void CombineItemTest()
    {
        // Arrange
        var armourFactory = new ArmourFactory(4);
        var armour = armourFactory.Create();
        var improveStrategy = new CombineStrategy(armour);
        var system = new InventorySystem(improveStrategy);
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        system.AddItem(playerBob, weapon);

        // Act

        system.ImproveItem(weapon);

        // Assert
        Assert.Equal(4, weapon.Health);
    }

    [Fact]
    public void EquipItemTest()
    {
        // Arrange
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);

        // Act
        var playerBob  = playerBuilder.WithItem(weapon).Build();

        // Assert
        Assert.Equal(7, playerBob.Power);
    }

    [Fact]
    public void CantEquipQuestItemWithoutQuest()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(0, 3);
        var questItem = new QuestItem(3,4);
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        var system = new InventorySystem(improveStrategy);
        system.AddItem(playerBob, questItem);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => system.TryEquipItem(playerBob, questItem));
    }

    [Fact]
    public void CanEquipQuestItemWithQuest()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(0, 3);
        QuestItem questItem = new QuestItem(3,4);
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        var system = new InventorySystem(improveStrategy);
        system.AddItem(playerBob, questItem);
        playerBob.CompleteQuest();
        questItem.CheckQuesComplited(playerBob);

        // Act
        bool equipingResult = system.TryEquipItem(playerBob, questItem);
        
        // Assert
        Assert.True(equipingResult);
    }

    [Fact]
    public void ChangeImprovingStrategy()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(0, 3);
        var armourFactory = new ArmourFactory(4);
        var armour = armourFactory.Create();
        var combineStrategy = new CombineStrategy(armour);
        var system = new InventorySystem(improveStrategy);
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        system.AddItem(playerBob, weapon);

        // Act
        system.ImproveItem(weapon);
        system.ChangeImproveStrategy(combineStrategy);
        system.ImproveItem(weapon);

        // Assert
        Assert.Equal(7, weapon.Power);
        Assert.Equal(4, weapon.Health);
    }

    [Fact]
    public void CantEquipOneItemTwice()
    {
        // Arrange
        var improveStrategy = new UpgradeStrategy(3, 3);
        var system = new InventorySystem(improveStrategy);
        var weaponFactory = new WeaponFactory(4);
        var weapon = weaponFactory.Create();
        var playerBuilder = new PlayerBuilder("bob", 4, 3);
        var playerBob  = playerBuilder.Build();
        system.AddItem(playerBob, weapon);

        // Act
        var firstResult =  playerBob.TryEquipNewItem(weapon);
        var SecondResult =  playerBob.TryEquipNewItem(weapon);
        
        // Assert
        Assert.True(firstResult);
        Assert.False(SecondResult);
    }

}