using DG.Tweening;

namespace Enemy
{
    public class EnemyIngressState : EnemyBaseState
    {
        private float _ingressSpeed = 5f;
        public override void EnterState(EnemyStateManager enemy)
        {
            enemy.transform.DOMoveY(4, _ingressSpeed).SetSpeedBased(true)
                .OnComplete(() => enemy.SwitchState(enemy.EnemyPatrolState));
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            
        }

        public override void ExitState(EnemyStateManager enemy)
        {
            
        }
    }
}