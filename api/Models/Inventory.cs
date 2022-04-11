namespace api;

/// <summary>
/// a list of inventory items in stock
/// </summary>
public class Inventory : IInventory
{
    private List<InventoryItem> _items;

    public Inventory()
    {
        _items = new List<InventoryItem>();
    }

    /// <summary>
    /// Allow passing in a list of inventory items during constructor.
    /// </summary>
    /// <param name="items">A list of well-typed inventory items.</param>
    public void SetItems(List<InventoryItem> items)
    {
        _items = items;
    }

    public void AddItem(InventoryItem value)
    {
        _items.Add(value);
    }

    public List<InventoryItem> GetItems()
    {
        return _items;
    }
    public InventoryItem[] GetItemArray()
    {
        return _items.ToArray();
    }

    public int Count()
    {
        return _items.Count;
    }

    public InventoryItem GetItem(int id)
    {
        if (_items.Count >= id)
        {
            if (_items[id] != null)
            {
                return _items[id];
            }
        }

        string exMsg = $"Index {id} was out of range.";
        throw new IndexOutOfRangeException(exMsg);
    }
}
