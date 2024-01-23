using UnityEngine;

public class EnemyAnimControll : MonoBehaviour
{
    public GameObject onDeathFX;
    void OnDeath()
    {
        var a = Instantiate(onDeathFX, transform.position + new Vector3(0,1.5f,0), transform.rotation);
        if (GetComponentInParent<AEnemy>())
        {
            GetComponentInParent<AEnemy>().Death();
        }
        else
        {
            GetComponentInParent<WarChief>().Death();
        }
    }


    void ReturnToIdle()
    {
        GetComponentInParent<Animator>().SetBool("isIdle", true);
    }
}
