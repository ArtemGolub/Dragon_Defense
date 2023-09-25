using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<int, InventoryItem> Items { get; } = new Dictionary<int, InventoryItem>();
    
    public void AddItem(int itemID, InventoryItem item, Transform inventoryPosition)
    {
        if (!Items.ContainsKey(itemID))
        {
            Items.Add(itemID, item);
            PlaceItem(inventoryPosition, item);
        }
    }
    
    public void PlaceItem(Transform inventoryPosition, InventoryItem item)
    {
        item.transform.SetParent(inventoryPosition);
    }

    public void DropItems()
    {
        List<int> itemsToRemove = new List<int>();
        foreach (var itemEntry in Items)
        {
            int itemID = itemEntry.Key;
            InventoryItem item = itemEntry.Value;

            itemsToRemove.Add(itemID);
            item.transform.SetParent(null);
            item.transform.parent = null;
        }
        foreach (int itemID in itemsToRemove)
        {
            Items.Remove(itemID);
        }
    }
    
}