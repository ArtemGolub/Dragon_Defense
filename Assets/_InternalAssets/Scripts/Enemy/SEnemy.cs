using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New SEnemy", menuName = "Custom/New Enemy")]
public class SEnemy : ScriptableObject
{
    public GameObject prefab;
    
    public float maxHp;
    public float maxDefence;
    public float maxSpeed;
    public int DamageValue;
}
