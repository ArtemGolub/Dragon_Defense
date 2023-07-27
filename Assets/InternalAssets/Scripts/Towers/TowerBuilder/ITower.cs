using UnityEngine;

public interface ITower
{
    AttackType AttackType { get; set; }
    IAttackStrategy attackStrategy { get; set; }
    float Damage { get; set; }
    public float ArmorReduction { get; set; }
    float AttackSpeed { get; set; }
    float AttackRange { get; set; }
}
