using NUnit.Framework;
using api.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;

namespace test;

public class InventoryControllerTests
{
    // using mock for ILogger not under test
    // no desire for logging while units under test
    private Mock<ILogger<InventoryController>>? mockILogger;
    private InventoryController? _inventoryController;


    [SetUp]
    public void Setup()
    {
        mockILogger = new Mock<ILogger<InventoryController>>();
        _inventoryController = new InventoryController(mockILogger.Object);
    }

    [Test]
    public void Inventory_GetFiveRecords()
    {
        // arrange
        api.Inventory[] records;

        if (_inventoryController != null)
        {
            // act
            records = (api.Inventory[])_inventoryController.Get();
            
            // assert
            Assert.IsNotNull(records);
            Assert.IsNotNull(mockILogger);
            if (mockILogger != null)
            {
                Assert.IsTrue(mockILogger.Invocations.Count == 1);
            }
            if (records != null)
            {
                Assert.AreEqual(5, records.Length);
                foreach (api.Inventory record in records) 
                {
                    Assert.GreaterOrEqual(record.ID, 0);
                    Assert.GreaterOrEqual(record.Kernels, 0);
                    Assert.IsInstanceOf(typeof(string), record.Name);
                    if (record.Name != null) {
                        if (typeof(string) == record.Name.GetType()) {
                            Assert.Greater(record.Name.Length, 0);
                            // length of string is always 15 in test data
                        }
                    }
                }
            }
        }
    }
}