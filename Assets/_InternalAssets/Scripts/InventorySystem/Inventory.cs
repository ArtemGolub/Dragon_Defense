using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private Dictionary<int, InventoryItem> Items { get; } = new Dictionary<int, InventoryItem>();
    private ParabolaMovement _parabolaMovement;
    
    public void AddItem(int itemID, InventoryItem item, Transform inventoryPosition)
    {
        if (!Items.ContainsKey(itemID))
        {
            if (inventoryPosition == null) return;
            Items.Add(itemID, item);
            PlaceItem(inventoryPosition, item);
        }
    }
    
    private void PlaceItem(Transform inventoryPosition,InventoryItem item)
    {
        if (inventoryPosition == null) return;
        item.transform.SetParent(inventoryPosition);
        item._parabolaMovement = new ParabolaMovement(item.transform, Vector3.zero,4.0f, 1);
        item._parabolaMovement.StartMovement();
    }
    
    public void DropItems()
    {
        List<int> itemsToRemove = new List<int>();
        foreach (var itemEntry in Items)
        {
            int itemID = itemEntry.Key;
            InventoryItem item = itemEntry.Value;
            
            item._parabolaMovement.StopMovement();
            
            itemsToRemove.Add(itemID);
            item.transform.SetParent(null);
            
            RaycastHit hit;
            Vector3 groundPosition = Vector3.zero;
            Vector3 raycastStartPosition = item.transform.position + Vector3.up * 0.1f;
            
            if (Physics.Raycast(raycastStartPosition, Vector3.down, out hit))
            {
                groundPosition = hit.point;
            }
            
            item.transform.position = groundPosition;
        }
        foreach (int itemID in itemsToRemove)
        {
            Items.Remove(itemID);
        }
    }
}