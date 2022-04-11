namespace api
{
    /// <summary>
    /// a list of inventory items in stock
    /// </summary>
    public class Inventory : IInventory
    {
        private readonly List<InventoryItem> _items;

        public Inventory()
        {
            _items = new List<InventoryItem>();
        }

        /// <summary>
        /// Allow passing in a list of inventory items during constructor.
        /// </summary>
        /// <param name="items">A list of well-typed inventory items.</param>
        public Inventory(List<InventoryItem> items)
        {
            _items = items;
        }

        public InventoryItem[] GetItems()
        {
            return _items.ToArray();
        }

        public void AddItem(InventoryItem value)
        {
            _items.Add(value);
        }
    }
}
