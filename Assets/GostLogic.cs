using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GostLogic : MonoBehaviour
{
    private GostInventory _inventory;

    public Transform moveToPoint;

    public void StartMovement()
    {
        transform.DOMove(moveToPoint.position, 5).onComplete = OnMovementEnd;
    }

    private void OnMovementEnd()
    {
        GetComponentInChildren<Animator>().SetBool("isJump", true);
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
