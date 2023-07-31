
using UnityEngine;
using StateManager;

    public class Tower_SM: MonoBehaviour
    {
        public StateMachine _SM;
        
        private Tower_Idle TowerIdle;
        public Tower_Shoot TowerShoot;
        
        private void InitStates()
        {
            _SM = new StateMachine();
            TowerIdle = new Tower_Idle(GetComponent<Tower>());
            TowerShoot = new Tower_Shoot(this, TowerIdle);
            _SM.Initialize(TowerIdle);
        }
        
        private void Awake()
        {
            InitStates();
        }

        private void Update()
        {
            _SM.CurrentState.Update();
        }
    }