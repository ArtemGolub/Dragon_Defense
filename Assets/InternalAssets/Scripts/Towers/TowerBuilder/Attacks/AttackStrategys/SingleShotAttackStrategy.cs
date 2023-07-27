using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotAttackStrategy : IAttackStrategy
{
    public void Attack(Transform target, ATower tower)
    {
        Debug.Log("Did attack");
    }
}
