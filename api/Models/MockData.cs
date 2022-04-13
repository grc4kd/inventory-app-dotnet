using System.Text.Json.Serialization;

namespace api
{
    public class MockData
    {
        [JsonPropertyName("inventory")]
        public List<InventoryItem>? InventoryItems { get; set; }
        [JsonPropertyName("requests")]
        public List<StoresRequest>? Requests { get; set; }
    }
}
