using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public List<Transform> inventoryPosition;

    public void PickUpItem(int itemID,InventoryItem item)
    {
        if (GetComponent<AEnemy>().CurHp <= 0) return;
        inventory.AddItem(itemID,item, inventoryPosition);
    }

    public void DropAllItems()
    {
        inventory.DropItems();
    }

    public void GetItemFromGost()
    {
        GostInventory.instance.SendItem(inventory, inventoryPosition);
    }
}