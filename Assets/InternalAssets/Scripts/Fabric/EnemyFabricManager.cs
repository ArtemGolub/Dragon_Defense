using UnityEngine;

public class EnemyFabricManager
{
    private IEnemyFabric fabric;

    public void SetUnitFabric(IEnemyFabric fabric)
    {
        this.fabric = fabric;
    }

    public void CreateAndInitializeEnemy(EnemyData settings, Transform spawnPoint, Transform container)
    {
        IEnemy unit = fabric.CreateObject(settings, spawnPoint, container);
        unit.UnitInit();
        
    }
}
