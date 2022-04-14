using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public InventoryController(ILogger<InventoryController> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        if (logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Logging is on.");
        }
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<InventoryItem>> Get()
    {
        // dependency injection, client wired up through 
        // both high level and low level modules depend on abstractions
        var client = _httpClientFactory.CreateClient("mocki");

        // async on io-bound task, possible delay while fetching content from WWW
        HttpResponseMessage response = await client.GetAsync("v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60");
        if (response.IsSuccessStatusCode)
        {
            MockData? mockTask = await response.Content.ReadFromJsonAsync<MockData>();
            if (mockTask != null
                && mockTask.InventoryItems != null)
            {
                // IInventory interface method is abstract 
                // concrete implementation is used at runtime
                return mockTask.InventoryItems;
            }
        }

        return Array.Empty<InventoryItem>();
    }    
}
