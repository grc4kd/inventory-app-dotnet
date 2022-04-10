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

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetInventory")]
    public IEnumerable<Inventory> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Inventory
        {
            ID = index,
            Kernels = Random.Shared.Next(0, 2048),
            Name = Names[Random.Shared.Next(Names.Length)]
        })
        .ToArray();
    }
}
