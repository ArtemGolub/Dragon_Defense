using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void MoveBullet();
    void Seek(Transform target);
    void HitTarget();
}
