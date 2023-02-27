using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBaseState
    {
        public abstract void EnterState(EnemyController enemy);
  
        public abstract void UpdateState(EnemyController enemy);
        
        public abstract void ExitState(EnemyController enemy);
    }
}