using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;

    static HttpClient client = new HttpClient();

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
        string message = $"Logging to ${_logger}";
        _logger.Log(LogLevel.Debug, message);
    }

    [HttpGet(Name = "GetInventory")]
    public async Task<Inventory> Get(string path)
    {
        // async on io-bound task (still pretty fast though)
        HttpResponseMessage response = await client.GetAsync(path);
        Inventory inventory = new();
        if (response.IsSuccessStatusCode)
        {
            Task<Model.MockData?> mockTask = 
                response.Content.ReadFromJsonAsync<Model.MockData>();
            if (mockTask != null)
            {
                Model.MockData? mockResult = mockTask.Result;
                if (mockResult != null
                    && mockResult.Inventory != null)
                {
                    inventory = new Inventory(mockResult.Inventory);
                }
            }
        }

        return inventory;
    }
}
