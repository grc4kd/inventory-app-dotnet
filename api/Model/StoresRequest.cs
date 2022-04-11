using System.Text.Json.Serialization;

namespace api.Model
{
    public class StoresRequest
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("inventoryId")]
        public int InventoryID { get; set; }
        [JsonPropertyName("requestedKernels")]
        public int RequestedKernels { get; set; }
    }
}