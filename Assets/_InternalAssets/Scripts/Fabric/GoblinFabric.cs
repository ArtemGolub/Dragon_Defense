using UnityEngine;

public class GoblinFabric : MonoBehaviour, IEnemyFabric
{
    private static int _ID;
    public IEnemy CreateObject(SEnemy settings, Transform spawnPoint, Transform container)
    {
        var newObject = Instantiate(settings.prefab, spawnPoint.position, spawnPoint.rotation);
        newObject.name += "ID: " + _ID;
        _ID++;
        if (container != null)
        {
            newObject.transform.SetParent(container);
        }
        Goblin objectComponent;
        if (!newObject.transform.GetComponent<Goblin>())
        {
            objectComponent = newObject.AddComponent<Goblin>();
        }
        else
        {
            objectComponent = newObject.transform.GetComponent<Goblin>();
        }
        objectComponent.preset = settings;
        return objectComponent;
    }
}

