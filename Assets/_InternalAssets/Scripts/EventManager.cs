using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    
    [HideInInspector]public UnityEvent<int> RemoveWinPoints = new UnityEvent<int>();
    [HideInInspector]public UnityEvent PlayerLose = new UnityEvent();

    public void OnRemoveWinPoints(int removePoints)
    {
        RemoveWinPoints.Invoke(removePoints);
    }

    public void OnPlayerLose()
    {
        PlayerLose.Invoke();
    }

    private void Awake()
    {
        instance = this;
    }
}
