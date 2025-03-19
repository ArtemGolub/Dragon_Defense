using UnityEngine;

[CreateAssetMenu(fileName = "New STower", menuName = "Custom/New AttackTower")]
public class SAttackTower: ScriptableObject
{
    public AttackType AttackType;
    public float Damage;
    public float AttackSpeed;
    public float AttackRange;
    public GameObject BulletPrefab;
}