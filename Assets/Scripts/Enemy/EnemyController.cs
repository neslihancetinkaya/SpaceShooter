using System;
using UnityEngine;
using Utils.ReferenceValues;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyBaseState _currentState;
        
        public EnemyWaitState EnemyWaitState = new EnemyWaitState();
        public EnemyPatrolState EnemyPatrolState = new EnemyPatrolState();
        public EnemyFollowState EnemyFollowState = new EnemyFollowState();
        public EnemyDieState EnemyDieState = new EnemyDieState();
        public EnemyIngressState EnemyIngressState = new EnemyIngressState();
        
        [SerializeField] private TransformRef PlayerTransform;
        
        public Vector3 motionDirection;
        public Vector3 motionTarget;


        private void Start()
        {
            _currentState = EnemyIngressState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(EnemyBaseState state)
        {
            _currentState = state;
            state.EnterState(this);
        }
    }
}