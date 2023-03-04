using UnityEngine;

namespace Enemy
{
    public class EnemyPatrolState : EnemyBaseState
    {
        public override void EnterState(EnemyController enemy)
        {
            float randX = Random.Range(-9, 9);
            float randY = Random.Range(-5, 5);
            enemy.motionTarget = new Vector2(randX, randY);
            enemy.motionDirection = (enemy.motionTarget - enemy.transform.position).normalized;
        }

        public override void UpdateState(EnemyController enemy)
        {
            if((enemy.motionTarget - enemy.transform.position).magnitude <= 2){
                EnterState(enemy);
            }
            else{
                enemy.transform.position += enemy.motionDirection * (1 * Time.deltaTime);
            }
        }

        public override void ExitState(EnemyController enemy)
        {
            
        }

    }
}