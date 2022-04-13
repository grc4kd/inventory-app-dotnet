using NUnit.Framework;
using api;
using System.Linq;
using System;

namespace test;

public class InventoryTests
{
    private InventoryItem? _inventoryItem;
    private readonly InventoryItem defaultItem = new()
    { ID = 0, Name = "", Kernels = 0 };
    private static readonly string[] Names = new[]
    { "24697-013-01-05", "24698-019-01-10", "24699-009-01-08" };

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Inventory_FieldSpecsAndDefaults()
    {
        _inventoryItem = defaultItem;
        Inventory inventory = new();

        inventory.AddItem(defaultItem);
        InventoryItem newItem = inventory.GetItem(_inventoryItem.ID);

        Assert.AreEqual(1, inventory.Count());
        Assert.AreEqual(_inventoryItem.ID, newItem.ID);
        Assert.AreEqual(_inventoryItem.Name, newItem.Name);
        Assert.AreEqual(_inventoryItem.Kernels, newItem.Kernels);
    }

    [Test]
    public void SillyInventory_Fields()
    {
        _inventoryItem = defaultItem;
        SillyInventory si = new();

        si.AddItem(defaultItem);
        InventoryItem newItem = si.GetItem(_inventoryItem.ID);

        Assert.AreEqual(newItem.ID, defaultItem.ID);
        Assert.AreNotEqual(newItem.Name, defaultItem.Name);
        Assert.IsTrue(newItem.Kernels == 42);
    }

    [Test]
    public void Inventory_GetItemArray()
    {
        Inventory _inventory = new();

        _inventory.SetItems(Enumerable.Range(1, 5)
            .Select(index => new InventoryItem
            {
                ID = index,
                Kernels = Random.Shared.Next(0, 2048),
                Name = Names[Random.Shared.Next(Names.Length)]
            })
            .ToList());

        Assert.AreEqual(5, _inventory.Count());

        Assert.IsNotNull(_inventory);

        if (_inventory != null)
        {
            for (int i = 0; i < _inventory.Count(); i++)
            {
                _inventoryItem = _inventory.GetItem(i);

                Assert.AreEqual(i + 1, _inventoryItem.ID);
                Assert.GreaterOrEqual(_inventoryItem.Kernels, 0);
                Assert.IsInstanceOf<string>(_inventoryItem.Name);
                Assert.NotNull(_inventoryItem.Name);
                if (_inventoryItem.Name != null)
                {
                    Assert.Greater(_inventoryItem.Name.Length, 0);
                }
            }
        }
    }
}