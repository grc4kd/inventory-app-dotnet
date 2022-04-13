using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;

    private const string defaultPath = "https://mocki.io/v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60";
    private string mockServerPath = defaultPath;

#pragma warning disable IDE0044 // Add readonly modifier
    static HttpClient client = new();
#pragma warning restore IDE0044 // Add readonly modifier

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
        if (logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Logging is on.");
        }
    }

    [HttpGet(Name = "GetInventory")]
    public async Task<IEnumerable<InventoryItem>> Get(string path = defaultPath)
    {
        // async on io-bound task, possible delay while fetching content from WWW
        HttpResponseMessage response = await client.GetAsync(path);
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

    [HttpPost("SetInventoryURL")]
    public IActionResult SetInventoryUrl(string path = defaultPath)
    {
        // don't reset the same path
        if (path == mockServerPath)
            return Ok();

        // set the default path for inventory controller
        // TODO: create _model_ for storing configuration data instead
        // validate input
        Uri uri;
        // forgive nulls here for local var uri!, some string exists from parse
        bool canParseUri = Uri.TryCreate(path, UriKind.Absolute, out uri!);
        if (canParseUri)
        {
            // validate Uri scheme
            if (uri.Scheme == Uri.UriSchemeHttp)
            {
                // set safe paths
                mockServerPath = path;
                return Ok();
            }
        }
        
        return BadRequest();
    }

    [HttpGet("requests")]
    public async Task<List<StoresRequest>> GetRequests()
    {
        // use the default path to obtain data
        // aka do not require this for REST call
        // I've decided the server should handle this responsibility
        HttpResponseMessage response = await client.GetAsync(mockServerPath);
        List<StoresRequest> requests = new();

        if (response.IsSuccessStatusCode)
        {
            MockData? mockTask = await response.Content.ReadFromJsonAsync<MockData>();
            if (mockTask != null
                && mockTask.Requests != null)
            {
                requests = mockTask.Requests;
            }
        }

        return requests;
    }

    /// <summary>
    /// Get request by request id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("/requests/{id}")]
    public async Task<IActionResult> GetRequest(int id)
    {
        if (id < 1)
        {
            return BadRequest("Stores request ids start at 1.");
        }

        HttpResponseMessage response = await client.GetAsync(mockServerPath);
        if (response.IsSuccessStatusCode)
        {
            MockData? mockTask = await response.Content.ReadFromJsonAsync<MockData>();
            if (mockTask != null
                && mockTask.Requests != null)
            {
                if (mockTask.Requests.Count > id - 1)
                {
                    return Ok(mockTask.Requests[id - 1]);
                }
            }
        }
        return NotFound($"Could not find the stores request id: {id}");
    }
}
