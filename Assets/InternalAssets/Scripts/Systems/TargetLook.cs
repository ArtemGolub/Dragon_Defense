using UnityEngine;

public static class TargetLook
{
    public static void LookAtTarget(Transform looker, Transform target)
    {
        var lookPos =  target.position - looker.transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        looker.transform.rotation = Quaternion.Slerp(looker.transform.rotation, rotation, Time.deltaTime * 1000);
    }
}
