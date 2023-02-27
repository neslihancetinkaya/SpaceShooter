using DG.Tweening;

namespace Enemy
{
    public class EnemyIngressState : EnemyBaseState
    {
        private float _ingressSpeed = 5f;
        public override void EnterState(EnemyController enemy)
        {
            enemy.transform.DOMoveY(4, _ingressSpeed).SetSpeedBased(true)
                .OnComplete(() => enemy.SwitchState(enemy.EnemyPatrolState));
        }

        public override void UpdateState(EnemyController enemy)
        {
            
        }

        public override void ExitState(EnemyController enemy)
        {
            
        }
    }
}