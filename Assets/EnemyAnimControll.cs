using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControll : MonoBehaviour
{
    public GameObject onDeathFX;
    void OnDeath()
    {
        var a = Instantiate(onDeathFX, transform.position, transform.rotation);
        GetComponentInParent<AEnemy>().Death();
    }
}
