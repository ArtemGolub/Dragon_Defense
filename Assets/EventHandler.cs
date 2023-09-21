using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private void Start()
    {
        EventManager.instance.RemoveWinPoints.AddListener(OnWinPointsRemoved);
        EventManager.instance.PlayerLose.AddListener(OnPlayerLose);
    }
    
    private void OnWinPointsRemoved(int removedPoints)
    {
        GameManager.instance.CurHealthPoints -= removedPoints;
        if (GameManager.instance.CurHealthPoints <= 0)
        {
            EventManager.instance.OnPlayerLose();
        }
        HPController.intstance.UpdateText(GameManager.instance.CurHealthPoints);
    }

    private void OnPlayerLose()
    {
        Debug.Log("Player Lose");
    }
}
