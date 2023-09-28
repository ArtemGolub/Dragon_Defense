using UnityEngine;

public interface IEnemyFabric
{
    IEnemy CreateObject(EnemyData settings, Transform spawnPoint, Transform container);
}
