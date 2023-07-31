using UnityEngine;

public class BuildingModel
{
    public GameObject Prefab { get; private set; }

    public BuildingModel(GameObject prefab)
    {
        Prefab = prefab;
    }
}
