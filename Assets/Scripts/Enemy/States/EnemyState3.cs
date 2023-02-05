using UnityEngine;

namespace Enemy
{
    public class EnemyState3 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager, float deltaTime)
        {
            //Si ya ha llegado al checkpoint y ha empezado el timer, salimos.
            if (enemyManager.runTimer) return;
            if (enemyManager.waypoint != null)
            {
                //Comprobamos si esta en el waypoint y no se ha iniciado el timer. Si es asi,
                if (Vector2.Distance(enemyManager.transform.position, enemyManager.waypoint.position) < 0.05f && !enemyManager.runTimer)
                {
                    //Cambiamos el sprite al de las raices
                    ChangeSprite(enemyManager);
                    enemyManager.GetComponentInChildren<Animator>().SetBool("Walk", false);
                    
                    //Iniciamos el timer.
                    enemyManager.SetTimer();
                    enemyManager.runTimer = true;
                }
                //Si no, nos movemos al waypoint.
                else
                {
                    Vector2 dir = enemyManager.waypoint.position - enemyManager.transform.position;
                    dir.Normalize();
                    enemyManager.GetComponentInChildren<Animator>().SetBool("Walk", true);
                    enemyManager.rB.MovePosition(enemyManager.rB.position + (dir * enemyManager.defaultSpeed * deltaTime));
                }
            }
        }

        public override void OnStateEnter(EnemyManager enemyManager)
        {
            enemyManager.runTimer = false;
        }

        public override void ChangeSprite(EnemyManager enemyManager)
        {
            enemyManager.brote2.SetActive(false);
            enemyManager.raices.SetActive(true);
        }
    }
}
