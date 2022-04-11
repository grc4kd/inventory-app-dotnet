using System.Text.Json.Serialization;

namespace api;

public class InventoryItem
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("kernels")]
    public int Kernels { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
