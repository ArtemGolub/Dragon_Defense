using System.Collections.Generic;
using UnityEngine;

public class UnitFabric : MonoBehaviour
{
    private EnemyFabricManager _fabricManager;
    private Transform container;
    
  // [SerializeField] private EnemyType myFabricType;
    [SerializeField] private List<EnemyData> enemyData;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private EnemyType FabricType;
    
    public void SpawnEnemy()
    {
        EnemyData data = enemyData.Find(data => data.EnemyType == FabricType);
        _fabricManager.CreateAndInitializeEnemy(data, spawnPoint, container);
    }
    public void UpdateFabric(EnemyType myFabricType)
    {
        FabricType = myFabricType;
        _fabricManager = new EnemyFabricManager();
        switch (myFabricType)
        {
            case EnemyType.Goblin:
            {
                IEnemyFabric goblinFabric = new GoblinFabric();
                _fabricManager.SetUnitFabric(goblinFabric);
                break;
            }
            case EnemyType.Golem:
            {
                IEnemyFabric golemFabric = new GolemFabric();
                _fabricManager.SetUnitFabric(golemFabric);
                break;
            }
        }

        CreateContainer(myFabricType);
    }

    private void CreateContainer(EnemyType myFabricType)
    {
        var containerObject = new GameObject();
        container = containerObject.transform;
        container.name = myFabricType.ToString() + "Container";
        container.SetParent(this.transform);
    }
}

