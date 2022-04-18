using NUnit.Framework;
using api.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace test;

public class InventoryControllerTests
{
    // using mock for ILogger not under test
    // no desire for logging while units under test
    private Mock<ILogger<InventoryController>>? mockILogger;
    private InventoryController? _inventoryController;
    // TODO: set up a mock HttpClient with Moq.Contrib.HttpClient
    // or similar strategy / wrapper
    private Mock<IHttpClientFactory>? mockIHttpClientFactory;

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Inventory_GetMockRecords()
    {
        // setup mock objects
        mockILogger = new Mock<ILogger<InventoryController>>();
        mockIHttpClientFactory = new Mock<IHttpClientFactory>();

        Assert.Fail("This test depends on HTTP calls, so a mock for that would be optimal.");
        _inventoryController = new InventoryController(mockILogger.Object, mockIHttpClientFactory.Object);

        if (_inventoryController != null)
        {
            // act
            var _response = _inventoryController.Get();
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