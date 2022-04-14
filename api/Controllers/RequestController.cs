using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("requests")]
public class RequestController : Controller
{
    private readonly ILogger<RequestController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    // TODO: use options pattern / DI for config
    private readonly string mockServerPath = "v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60";

    public RequestController(ILogger<RequestController> logger,
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
    public async Task<List<StoresRequest>> GetRequests()
    {
        var client = _httpClientFactory.CreateClient("mocki");

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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRequest(int id)
    {
        var client = _httpClientFactory.CreateClient("mocki");

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
