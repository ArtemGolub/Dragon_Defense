using UnityEngine;

public class TestInput : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           var obj = Instantiate(prefab);
           BuildingSystem.Instance.objectToPlace = obj.GetComponent<PlaceableObject>();
           obj.transform.position = spawnPoint.position;
        }
    }
}
