using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SWave", menuName = "Custom/New Wave")]
public class SWave : ScriptableObject
{
    public EnemyType EnemyType;
    public int UnitsAmount;
    public float SpawnRate;
}
