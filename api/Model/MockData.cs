using System.Text.Json.Serialization;

namespace api.Model
{
    public class MockData
    {
        [JsonPropertyName("inventory")]
        public List<InventoryItem>? Inventory { get; set; }
        [JsonPropertyName("requests")]
        public List<StoresRequest>? Requests { get; set; }
    }
}
