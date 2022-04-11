namespace api
{
    // now obviously we wouldn't actually want to implement this
    // but I'm only using it as an example of changing behavior with DIC
    public class SillyInventory : IInventory
    {
        private readonly List<InventoryItem> _items;

        public SillyInventory()
        {
            _items = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem value)
        {
            _items.Remove(value);
        }

        public int Count()
        {
            return _items.Count;
        }

        public InventoryItem GetItem(int id)
        {
            return new InventoryItem
            {
                ID = id,
                Name = "s14r-7i3a-rtf45",
                Kernels = 42
            };
        }

        // leave this method un-silly for testing
        public List<InventoryItem> GetItems()
        {
            return _items;
        }

        /// <summary>
        /// Assign to the inventory with a very silly algorithm.
        /// </summary>
        /// <param name="items">A list of items to add to the inventory.</param>
        public void SetItems(List<InventoryItem> items)
        {
            // high water mark
            int hwm = items.Count;
            hwm = hwm > _items.Count ? hwm : _items.Count;

            _items.AddRange(items.GetRange(0, hwm / 2));
        }
    }
}