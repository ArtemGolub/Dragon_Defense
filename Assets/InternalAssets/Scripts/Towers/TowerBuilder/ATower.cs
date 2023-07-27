using UnityEngine;

public abstract class ATower : MonoBehaviour, ITower
{
    public STower preset;
    
    public AttackType AttackType { get; set; }
    public IAttackStrategy attackStrategy { get; set; }
    public float Damage { get; set; }
    public float ArmorReduction { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }



    public abstract void Attack(Transform target);

    protected void TowerInit()
    {
        AttackType = preset.AttackType;
        SetAttackStrategy(AttackType);
        Damage = preset.Damage;
        ArmorReduction = preset.ArmorReduction;
        AttackSpeed = preset.AttackSpeed;
        AttackRange = preset.AttackRange;
    }

    private void SetAttackStrategy(AttackType attackType)
    {
        attackStrategy = AttackStrategyFactory.CreateStrategy(attackType);
    }
  
    
    
}
