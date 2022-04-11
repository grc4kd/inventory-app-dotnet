using NUnit.Framework;
using api;

namespace test;

public class InventoryTests
{
    private InventoryItem? _inventory;

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Inventory_FieldSpecsAndDefaults()
    {
        int id = 0;
        string name = "";
        int kernels = 0;

        _inventory = new InventoryItem
        {
            ID = id,
            Name = name,
            Kernels = kernels
        };

        if (_inventory != null)
        {
            Assert.AreEqual(
                (id, name, kernels),
                (_inventory.ID, _inventory.Name, _inventory.Kernels)
            );
        }
    }
}