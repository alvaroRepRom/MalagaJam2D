using UnityEngine;

namespace Enemy
{
    public class EnemyState1 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager, float deltaTime)
        {
            //Si no está interactuando, nos movemos hacia la salida.
            if (enemyManager.interacting) return;
            Vector2 dir = enemyManager.exit.position - enemyManager.transform.position;
            dir.Normalize();
            enemyManager.rB.MovePosition(enemyManager.rB.position + (dir * enemyManager.root1Speed * deltaTime));
        }

        public override void OnStateEnter(EnemyManager enemyManager)
        {
            ChangeSprite(enemyManager);
            Debug.Log("Raices 1");
        }

        public override void ChangeSprite(EnemyManager enemyManager)
        {
            enemyManager.brote1.SetActive(true);
            enemyManager.brote2.SetActive(false);
        }
    }
}