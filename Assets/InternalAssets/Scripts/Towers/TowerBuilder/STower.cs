using UnityEngine;

[CreateAssetMenu(fileName = "New STower", menuName = "Custom/New Tower")]
public class STower : ScriptableObject
{
    public AttackType AttackType;
    public float Damage;
    public float ArmorReduction;
    public float AttackSpeed;
    public float AttackRange;
}
