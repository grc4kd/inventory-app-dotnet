using System.Text.Json.Serialization;

namespace api
{
    public class MockData
    {
        [JsonPropertyName("inventory")]
        public List<InventoryItem>? InventoryItems { get; set; }
        [JsonPropertyName("requests")]
        public List<StoresRequest>? Requests { get; set; }

        public List<InventoryItem> GetInventoryList(IInventory inventory) { 
            if (InventoryItems != null)
            {
                inventory.SetItems(InventoryItems);
            }

            if (inventory.Count() > 0)
            {
                return inventory.GetItems();
            }

            return new List<InventoryItem>();
        }
    }
}
