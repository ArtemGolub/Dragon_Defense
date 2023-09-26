using System;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    private Inventory inventory = new Inventory();
    public Transform inventoryPosition;
    
    public void PickUpItem(int itemID,InventoryItem item)
    {
        if (GetComponent<AEnemy>().CurHp <= 0) return;
        inventory.AddItem(itemID,item, inventoryPosition);
    }

    public void DropAllItems()
    {
        inventory.DropItems();
    }
}