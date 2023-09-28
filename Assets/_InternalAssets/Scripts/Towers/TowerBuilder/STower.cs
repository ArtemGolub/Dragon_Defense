using UnityEngine;

[CreateAssetMenu(fileName = "New STower", menuName = "Custom/New Tower")]
public class STower : ScriptableObject
{
    public string TowerName;
    public TowerType TowerType;
    public GameObject model;
}
