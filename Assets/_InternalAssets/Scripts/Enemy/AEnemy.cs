using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;


public abstract class AEnemy : MonoBehaviour, IEnemy
{
    
    [HideInInspector]public EnemyData preset;
    public EnemyData Preset
    {
        get { return preset; }
        set { preset = value; }
    }
    
    public float CurHp { get; private set; }
    public float MaxHp { get; private set; }
    public int DamageValue { get; private set; }
    public float CurDefence { get; private set; }
    public float MaxDefence { get; private set; }
    public float CurSpeed { get; private set; }
    public float MaxSpeed { get; private set; }
    
    private IMoveStrategy moveStrategy;

    [HideInInspector]public List<Transform> wayPoints;

    private AIPath _aiPath;
    
    public void UnitInit()
    {
        MaxHp = Preset.maxHp;
        CurHp = MaxHp;

        MaxDefence = Preset.maxDefence;
        CurDefence = MaxDefence;

        MaxSpeed = Preset.maxSpeed;
        CurSpeed = MaxSpeed;

        DamageValue = Preset.DamageValue;

        wayPoints = WayPointsManager.Instance.allWaypoints;


        _aiPath = GetComponent<AIPath>();
        _aiPath.maxSpeed = CurSpeed;
        
        transform.position = WayPointsManager.Instance.spawnPoint.transform.position;
    }

    public void Finished()
    {
        EventManager.instance.OnRemoveWinPoints(DamageValue);
        Destroy(this.gameObject);
    }

    public void SetMoveStrategy(IMoveStrategy strategy)
    {
        moveStrategy = strategy;
    }

    protected void Move()
    {
        if (moveStrategy != null)
            moveStrategy.Move(wayPoints, _aiPath);
    }
    
    public void ReciveDamage(float amount)
    {
        CurHp -= amount - (amount / 100 * CurDefence);
        if (CurHp <= 0)
        {
            GetComponent<EnemyInventory>().DropAllItems();
            GetComponentInChildren<Animator>().SetBool("isDead", true);
            _aiPath.isStopped = true;
            tag = "DeadEnemy";
        }
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
        _aiPath.maxSpeed = CurSpeed;
        yield return new WaitForSeconds(time);
        CurSpeed = MaxSpeed;
        _aiPath.maxSpeed = CurSpeed;
    }

    public void Death()
    {
        
        Destroy(this.gameObject);
    }
    
}
