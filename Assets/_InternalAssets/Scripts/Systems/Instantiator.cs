using UnityEngine;

public static class Instantiator
{
    public static GameObject InstantiateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(prefab, position, rotation);
    }
}
