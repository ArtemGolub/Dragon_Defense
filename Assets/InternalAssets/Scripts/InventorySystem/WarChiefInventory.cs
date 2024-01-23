using System.Collections.Generic;
using UnityEngine;

public class WarChiefInventory : MonoBehaviour
{
    public static WarChiefInventory instance;
    
    private Inventory inventory = new Inventory();
    public List<Transform> inventoryPositions;
    public List<InventoryItem> items;

    
    private void Start()
    {
        instance = this;
        inventory.AddNextItem(inventory, items, this.gameObject.transform);
    }

    public void SendItem(Inventory toInventory, List<Transform> inventoryPosition)
    {
        if(items == null) return;
        GetComponentInChildren<Animator>().SetBool("isIdle", false);
        inventory.SendOneItem(inventory, toInventory, inventoryPosition);
        inventory.AddNextItem(inventory, items, this.gameObject.transform);
    }
}
