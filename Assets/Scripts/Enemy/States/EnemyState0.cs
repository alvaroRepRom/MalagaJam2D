using UnityEngine;

namespace Enemy
{
    public class EnemyState0 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager, float deltaTime)
        {
            //Nos movemos a la salida a gran velocidad si no estamos interactuando.
            if (enemyManager.interacting) return;
            Vector2 dir = enemyManager.exit.position - enemyManager.transform.position;
            dir.Normalize();
            enemyManager.rB.MovePosition(enemyManager.rB.position + (dir * enemyManager.root0Speed * deltaTime));
            enemyManager.GetComponentInChildren<Animator>().SetBool("Walk", true);
        }

        public override void OnStateEnter(EnemyManager enemyManager)
        {
            ChangeSprite(enemyManager);
            Debug.Log("Raices 0");
        }

        public override void ChangeSprite(EnemyManager enemyManager)
        {
            enemyManager.brote1.SetActive(false);
        }
    }
}
