using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllTest : MonoBehaviour
{

    public void InitBullet()
    {
        GetComponentInParent<AtackTower>().attackStrategy.Shoot();
    }
    
    public void StopAttack()
    {
        GetComponent<Animator>().SetBool("isAttack", false);
    }
}
