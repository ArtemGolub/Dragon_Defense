using System;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    private Inventory inventory = new Inventory();
    public Transform inventoryPosition;
    
    public void PickUpItem(int itemID,InventoryItem item)
    {
        inventory.AddItem(itemID,item, inventoryPosition);
    }
    public void PlaceItem(InventoryItem item)
    {
        item.transform.SetParent(inventoryPosition);
    }
    public void DropAllItems()
    {
        inventory.DropItems();
    }
}