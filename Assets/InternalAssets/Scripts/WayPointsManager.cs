using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager: MonoBehaviour
{
    public static WayPointsManager Instance { get; private set; }

    public Transform spawnPoint;
    public List<Transform> allWaypoints;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
