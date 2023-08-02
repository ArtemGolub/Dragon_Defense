using UnityEngine;
using StateManager;

public class Enemy_SM : MonoBehaviour
{
    private StateMachine _SM;
    private Enemy_Idle _idle;
    
    private int moveIndex;
    
    private void Awake()
    {
        InitStates();
    }

    private void Update()
    {
        _SM.CurrentState.Update();
    }
    
    private void InitStates()
    {
        _SM = new StateMachine();
        _idle = new Enemy_Idle();

        _SM.Initialize(_idle);
    }
}