using NUnit.Framework;
using api;

namespace test;

public class InventoryTests
{
    private int _id, _kernels;
    private string? _name;
    private Inventory? _inventory;

    [SetUp]
    public void Setup()
    {
        _id = 0;
        _name = "";
        _kernels = 0;

        _inventory = new Inventory
        {
            ID = _id,
            Name = _name,
            Kernels = _kernels
        };
    }

    [Test]
    public void Inventory_FieldSpecsAndDefaults()
    {
        Assert.IsNotNull(_inventory);

        if (_inventory != null)
        {
            Assert.AreEqual(
                (_inventory.ID, _inventory.Name, _inventory.Kernels),
                (_id, _name, _kernels)
            );
        }
    }
}