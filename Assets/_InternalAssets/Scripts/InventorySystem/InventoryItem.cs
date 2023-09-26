using System;
using UnityEngine;

public class InventoryItem: MonoBehaviour, IInventoryItem
{
    public ItemData itemData;
    public ParabolaMovement _parabolaMovement;
    private EnemyInventory _enemyInventory;
    public string Name { get; set; }
    public int ID { get; set; }
    public bool onBoss;
    
    private void Start()
    {
        Name = itemData.Name;
        ID = itemData.ID;
    }

    private void Update()
    {
        if(_parabolaMovement == null) return;
        if (_parabolaMovement.IsMoving())
        {
            _parabolaMovement.UpdateMovement();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        EnemyInventory enemyInventory = other.GetComponent<EnemyInventory>();
        if (enemyInventory && !onBoss)
        {
            _enemyInventory = enemyInventory;
            enemyInventory.PickUpItem(ID, this);
        }
    }

    
}
