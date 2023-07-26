using UnityEngine;

public interface IEnemyFabric
{
    IEnemy CreateObject(SEnemy settings, Transform spawnPoint, Transform container);
}
