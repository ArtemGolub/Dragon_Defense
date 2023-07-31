using UnityEngine;

[CreateAssetMenu(fileName = "New STower", menuName = "Custom/New Tower")]
public class STower : ScriptableObject
{
    public TowerType TowerType;
    public GameObject model;
}
