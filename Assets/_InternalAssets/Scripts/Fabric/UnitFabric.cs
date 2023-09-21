using UnityEngine;

public class UnitFabric : MonoBehaviour
{
    private EnemyFabricManager _fabricManager;
    private Transform container;
    
  // [SerializeField] private EnemyType myFabricType;
    [SerializeField] private SEnemy settings;
    [SerializeField] private SEnemy goblinSettings;
    [SerializeField] private SEnemy golemSettings;
    [SerializeField] private Transform spawnPoint;
    
    public void SpawnEnemy()
    {
        _fabricManager.CreateAndInitializeEnemy(settings, spawnPoint, container);
    }

    // TODO settings should be set automaticly
    // TODO new GoblinFabric(); should not be Monobeh
    // TODO All setting should be send from WaveController
    public void UpdateFabric(EnemyType myFabricType)
    {
        _fabricManager = new EnemyFabricManager();
        switch (myFabricType)
        {
            case EnemyType.Goblin:
            {
                IEnemyFabric goblinFabric = new GoblinFabric();
                _fabricManager.SetUnitFabric(goblinFabric);
                settings = goblinSettings;
                Debug.Log("goblin");
                break;
            }
            case EnemyType.Golem:
            {
                IEnemyFabric golemFabric = new GolemFabric();
                _fabricManager.SetUnitFabric(golemFabric);
                settings = golemSettings;
                Debug.Log("golem");
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
