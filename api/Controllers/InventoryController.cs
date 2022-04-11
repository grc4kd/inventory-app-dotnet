using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IInventory _inventory;

#pragma warning disable IDE0044 // Add readonly modifier
    static HttpClient client = new();
#pragma warning restore IDE0044 // Add readonly modifier

    public InventoryController(ILogger<InventoryController> logger, IInventory inventory)
    {
        _logger = logger;
        if (logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Logging is on.");
        }

        _inventory = inventory;
    }

    [HttpGet(Name = "GetInventory")]
    public async Task<IEnumerable<InventoryItem>> Get(string path)
    {
        // async on io-bound task (still pretty fast though)
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            MockData? mockTask = await response.Content.ReadFromJsonAsync<MockData>();
            if (mockTask != null)
            {
                return mockTask.GetInventoryList(_inventory);
            }
        }

        return Array.Empty<InventoryItem>();
    }
}
