using System.Collections.Generic;
using UnityEngine;

public class GostInventory : MonoBehaviour
{
    public static GostInventory instance;
    
    private Inventory inventory = new Inventory();
    public List<Transform> inventoryPositions;
    public List<InventoryItem> items;

    
    private void Start()
    {
        instance = this;
        inventory.AddNextItem(inventory, items);
    }

    public void SendItem(Inventory toInventory, List<Transform> inventoryPosition)
    {
        if(items == null) return;
        inventory.SendOneItem(inventory, toInventory, inventoryPosition);
        inventory.AddNextItem(inventory, items);
    }
}
