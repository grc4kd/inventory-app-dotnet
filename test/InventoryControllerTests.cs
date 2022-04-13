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

    private const string mockDataPath = "https://mocki.io/v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60";

    [SetUp]
    public void Setup()
    {
        mockILogger = new Mock<ILogger<InventoryController>>();
        _inventoryController = new InventoryController(mockILogger.Object);
    }

    [Test]
    public void Inventory_GetMockRecords()
    {
        if (_inventoryController != null)
        {
            // act
            var _response = _inventoryController.Get(mockDataPath);
            List<api.InventoryItem> records = (List<api.InventoryItem>)_response.Result;
            
            // assert
            Assert.IsNotNull(records);
            Assert.IsNotNull(mockILogger);
            if (mockILogger != null)
            {
                Assert.IsTrue(mockILogger.Invocations.Count == 1);
                Assert.DoesNotThrow(() => mockILogger.Verify());
            }
            if (records != null)
            {
                Assert.AreEqual(3, records.Count);
                foreach (api.InventoryItem record in records) 
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