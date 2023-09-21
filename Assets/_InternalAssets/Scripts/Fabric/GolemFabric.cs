using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemFabric : MonoBehaviour, IEnemyFabric
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
        Golem objectComponent;
        if (!newObject.transform.GetComponent<Golem>())
        {
            objectComponent = newObject.AddComponent<Golem>();
        }
        else
        {
            objectComponent = newObject.transform.GetComponent<Golem>();
        }
        objectComponent.preset = settings;
        return objectComponent;
    }
}
