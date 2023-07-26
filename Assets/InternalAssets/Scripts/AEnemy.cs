using System.Collections;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour, IEnemy
{
    public SEnemy Preset { get; set; }
    public float CurHp { get; private set; }
    public float MaxHp { get; private set; }
    public float CurDefence { get; private set; }
    public float MaxDefence { get; private set; }
    public float CurSpeed { get; private set; }
    public float MaxSpeed { get; private set; }
    
    protected void UnitInit()
    {
        MaxHp = Preset.maxHp;
        CurHp = MaxHp;

        MaxDefence = Preset.maxDefence;
        CurDefence = MaxDefence;

        MaxSpeed = Preset.maxSpeed;
        CurSpeed = MaxSpeed;
    }

    public void ReciveDamage(float amount)
    {
        CurHp -= amount - (amount / 100 * CurDefence);
    }

    
    public void LowerDefence(float percent, float time)
    {
        var loweredDefence = CurDefence - (CurDefence / 100 * percent);
        StartCoroutine(LowDefence(loweredDefence, time));
    }

    private IEnumerator LowDefence(float loweredDefence, float time)
    {
        CurDefence = loweredDefence;
        yield return new WaitForSeconds(time);
        CurDefence = MaxDefence;
    }

    
    public void SlowMoveSpeed(float percent, float time)
    {
        var loweredSpeed = CurSpeed - (CurSpeed / 100 * percent);
        StartCoroutine(LowerSpeed(loweredSpeed, time));
    }
    private IEnumerator LowerSpeed(float loweredSpeed, float time)
    {
        CurSpeed = loweredSpeed;
        yield return new WaitForSeconds(time);
        CurSpeed = MaxSpeed;
    }
    
}
