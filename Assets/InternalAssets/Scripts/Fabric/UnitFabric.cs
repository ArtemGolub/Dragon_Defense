using UnityEngine;

public class UnitFabric : MonoBehaviour
{
    private EnemyFabricManager _fabricManager;
    private Transform container;
    
    [SerializeField] private EnemyType myFabricType;
    [SerializeField] private float firstSpawnDelay = 1f;
    [SerializeField] private float repeatRate = 1f;
    [SerializeField] private SEnemy settings;
    [SerializeField] private Transform spawnPoint;
    
    private void Start()
    {
        CreateContainer();
        InitFactory();
        InvokeRepeating("SpawnEnemy", firstSpawnDelay, repeatRate);
    }
    
    private void InitFactory()
    {
        _fabricManager = new EnemyFabricManager();
        switch (myFabricType)
        {
            case EnemyType.Warrior:
            {
                IEnemyFabric archerFabric = new WarriorFabric();
                _fabricManager.SetUnitFabric(archerFabric);
                break;
            }
        }
    }
    private void SpawnEnemy()
    {
        _fabricManager.CreateAndInitializeEnemy(settings, spawnPoint, container);
    }

    private void CreateContainer()
    {
        var containerObject = new GameObject();
        container = containerObject.transform;
        container.name = myFabricType.ToString() + "Container";
        container.SetParent(this.transform);
    }
}
