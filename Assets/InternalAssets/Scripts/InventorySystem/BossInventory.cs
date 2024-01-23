using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInventory : MonoBehaviour
{
    private Inventory inventory = new Inventory();
    public List<Transform> inventoryPosition;

    public void GetAllItems(Inventory fromInventory)
    {
        inventory.GetAllItems(fromInventory,  inventory, inventoryPosition);
    }
}
