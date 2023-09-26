using System;
using UnityEngine;

public class InventoryItem: MonoBehaviour, IInventoryItem
{
    public ItemData itemData;
    private ParabolaMovement _parabolaMovement;
    private EnemyInventory _enemyInventory;
    
    public string Name { get; set; }
    public int ID { get; set; }

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
    
    private void OnMovementComplete()
    {
        _enemyInventory.PlaceItem(this);
        _parabolaMovement.OnComplete -= OnMovementComplete;
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyInventory enemyInventory = other.GetComponent<EnemyInventory>();
        if (enemyInventory)
        {
            _enemyInventory = enemyInventory;
            enemyInventory.PickUpItem(ID, this);
            
            _enemyInventory.PlaceItem(this);
            
            _parabolaMovement = new ParabolaMovement(transform, Vector3.zero,4.0f, 1);
            _parabolaMovement.OnComplete += OnMovementComplete;
            _parabolaMovement.StartMovement();
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     EnemyInventory enemyInventory = other.GetComponent<EnemyInventory>();
    //     if (enemyInventory)
    //     {
    //         _enemyInventory = enemyInventory;
    //         enemyInventory.PickUpItem(ID, this);
    //         _parabolaMovement = new ParabolaMovement(transform, enemyInventory.inventoryPosition.position, 4.0f, 1);
    //         _parabolaMovement.OnComplete += OnMovementComplete;
    //         _parabolaMovement.StartMovement();
    //     }
    // }
}
