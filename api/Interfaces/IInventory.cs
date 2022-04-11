namespace api
{
    public interface IInventory
    {
        InventoryItem[] GetItems();
        void AddItem(InventoryItem value);
    }
}