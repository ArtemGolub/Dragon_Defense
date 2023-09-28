using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private Dictionary<int, InventoryItem> Items { get; } = new Dictionary<int, InventoryItem>();
    private ParabolaMovement _parabolaMovement;
    private static int itemIdModificator;
    private static int itemIdModificator1;
    
    public void AddItem(int itemID, InventoryItem item, List<Transform> inventoryPosition)
    {
        if (!Items.ContainsKey(itemID))
        {
            if (inventoryPosition == null) return;
            Items.Add(itemID, item);
            PlaceItem(inventoryPosition, item);
        }
    }
    
    private void PlaceItem(List<Transform> inventoryPosition, InventoryItem item)
    {
        if (inventoryPosition == null || inventoryPosition.Count == 0) return;
        
        Transform availablePosition = null;
        foreach (Transform position in inventoryPosition)
        {
            if (position.childCount == 0)
            {
                availablePosition = position;
                break;
            }
        }

        if (availablePosition != null)
        {
            item.transform.SetParent(availablePosition);
            item._parabolaMovement = new ParabolaMovement(item.transform, Vector3.zero, 4.0f, 1);
            item.StartRotation(availablePosition);
            item._parabolaMovement.StartMovement();
        }
    }

    public void AddNextItem(Inventory inventory,List<InventoryItem> items)
    {
        if(items.Count <= 0) return;
        inventory.Items.Add(items[0].ID, items[0]);
        items.Remove(items[0]);
    }
    
    public void SendOneItem(Inventory fromInventory, Inventory toInventory, List<Transform> inventoryPosition)
    {
        List<int> itemsToRemove = new List<int>();
        foreach (var itemEntry in fromInventory.Items)
        {
            int itemID = itemEntry.Key;
            itemsToRemove.Add(itemID);
        }
        foreach (int itemID in itemsToRemove)
        {
            toInventory.AddToUnitItem(itemID, fromInventory.Items[itemID], inventoryPosition);
            fromInventory.Items.Remove(itemID);
        }
    }

    private void AddToUnitItem(int itemID, InventoryItem item, List<Transform> inventoryPosition)
    {
        Items.Add(itemID, item);
        PlaceItem(inventoryPosition, item);
    }
    
    
    private void AddToBossItem(int itemID, InventoryItem item, List<Transform> inventoryPosition)
    {
        item.onBoss = true;
        Items.Add(itemID + itemIdModificator, item);
        PlaceItem(inventoryPosition, item);
        itemIdModificator++;
        
      
    }
    public void GetAllItems(Inventory fromInventory, Inventory toInventory, List<Transform> inventoryPosition)
    {
        List<int> itemsToRemove = new List<int>();
        foreach (var itemEntry in fromInventory.Items)
        {
            int itemID = itemEntry.Key;
            itemsToRemove.Add(itemID);
        }
        foreach (int itemID in itemsToRemove)
        {
            toInventory.AddToBossItem(itemID, fromInventory.Items[itemID], inventoryPosition);
            fromInventory.Items.Remove(itemID);
        }
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