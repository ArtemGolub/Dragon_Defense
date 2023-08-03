using UnityEngine;

public static class TargetLook
{
    public static void LookAtTarget(Transform looker, Transform target)
    {
        var lookPos =  target.position - looker.transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        looker.transform.rotation = Quaternion.Slerp(looker.transform.rotation, rotation, Time.deltaTime * 1000);
    }
    
    public static void LookAtTargetOnlyY(Transform looker, Transform target)
    {
        Vector3 lookPos = target.position - looker.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        Quaternion yRotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        looker.transform.rotation = Quaternion.Slerp(looker.transform.rotation, yRotation, Time.deltaTime * 1000);
    }
}
