using UnityEngine;

public class TestInput : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BuildingSystem.current.InitializeWithObject(prefab);
        }
    }
}
