namespace api
{
    public interface IInventory
    {
        /// <summary>
        /// Get one list item by it's item id.
        /// </summary>
        /// <param name="id">id of the element to return</param>
        /// <returns></returns>
        InventoryItem GetItem(int id);

        /// <summary>
        /// Get all list items at once.
        /// </summary>
        /// <returns></returns>
        List<InventoryItem> GetItems();

        /// <summary>
        /// Get the number of items in inventory.
        /// </summary>
        /// <returns>An integer count of each item.</returns>
        int Count();

        void AddItem(InventoryItem value);
        /// <summary>
        /// Set all list items at once.
        /// </summary>
        /// <param name="items">A complete list of items to load.</param>
        void SetItems(List<InventoryItem> items);
    }
}