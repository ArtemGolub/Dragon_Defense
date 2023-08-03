using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllTest : MonoBehaviour
{
    public void StopAttack()
    {
        GetComponent<Animator>().SetBool("isAttack", false);
    }
}
