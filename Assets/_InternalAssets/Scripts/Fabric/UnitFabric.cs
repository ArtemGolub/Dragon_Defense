using UnityEngine;

public class UnitFabric : MonoBehaviour
{
    private EnemyFabricManager _fabricManager;
    private Transform container;
    
  //  [SerializeField] private EnemyType myFabricType;
    [SerializeField] private SEnemy settings;
    [SerializeField] private Transform spawnPoint;
    
    public void SpawnEnemy()
    {
        _fabricManager.CreateAndInitializeEnemy(settings, spawnPoint, container);
    }

    public void UpdateFabric(EnemyType myFabricType)
    {
        _fabricManager = new EnemyFabricManager();
        switch (myFabricType)
        {
            case EnemyType.Warrior:
            {
                IEnemyFabric WarriorFabric = new WarriorFabric();
                _fabricManager.SetUnitFabric(WarriorFabric);
                Debug.Log("Warrior");
                break;
            }
            case EnemyType.Archer:
            {
                IEnemyFabric WarriorFabric = new WarriorFabric();
                _fabricManager.SetUnitFabric(WarriorFabric);
                Debug.Log("Archer");
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
