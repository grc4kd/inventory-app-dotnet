using Microsoft.AspNetCore.Mvc;

namespace inventory_app_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Inventory> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Inventory
        {
            ID = index,
            Name = "24697-013-01-05",
            Kernels = 75
        })
        .ToArray();
    }
}
