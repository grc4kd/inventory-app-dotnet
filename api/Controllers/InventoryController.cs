using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "24697-013-01-05", "24698-019-01-10", "24699-009-01-08", 
    };

    private readonly ILogger<InventoryController> _logger;

    static HttpClient client = new HttpClient();

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
        string message = $"Logging to ${_logger}";
        _logger.Log(LogLevel.Debug, message);
    }

    [HttpGet(Name = "GetInventory")]
    public async Task<Inventory[]> Get(string path)
    {
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var inventoryTask = response.Content.ReadFromJsonAsync<Inventory[]>();
            if (inventoryTask.Result != null)
            {
                return inventoryTask.Result;
            }
        }

        return Array.Empty<Inventory>();

        //return Enumerable.Range(1, 5).Select(index => new Inventory
        //{
        //    ID = index,
        //    Kernels = Random.Shared.Next(0, 2048),
        //    Name = Names[Random.Shared.Next(Names.Length)]
        //})
        //.ToArray();
    }
}
