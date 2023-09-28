using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Custom/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Fabric Setup")]
    public EnemyType EnemyType;
    public GameObject prefab;
    
    [Header("Unit Setup")]
    public float maxHp;
    public float maxDefence;
    public float maxSpeed;
    public int DamageValue;
}
