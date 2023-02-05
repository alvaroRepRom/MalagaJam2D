using UnityEngine;

namespace Enemy
{
    public class EnemyState2 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager, float deltaTime)
        {
            //Movimiento random dentro de la Party Zone con la velocidad root2
            if (enemyManager.interacting) return;
            if (enemyManager.waypoint != null)
            {
                //Comprobamos si esta en el waypoint, en ese caso se cambia el destino
                if (Vector2.Distance(enemyManager.transform.position, enemyManager.waypoint.position) < 0.05f )
                {
                    //Cambiamos el waypoint para indicarle el nuevo punto al que moverse en la zona de fiesta
                    enemyManager.ChangeWaypoint();
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
            ChangeSprite(enemyManager);
        }
        
        public override void ChangeSprite(EnemyManager enemyManager)
        {
            enemyManager.brote1.SetActive(false);
            enemyManager.brote2.SetActive(true);
            enemyManager.raices.SetActive(false);
        }
    }
}
