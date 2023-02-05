using UnityEngine;

namespace Enemy
{
    public class EnemyState1 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager)
        {
            //Si no está interactuando, nos movemos hacia la salida.
            if (enemyManager.interacting) return;
            Vector2 dir = enemyManager.exit.position - enemyManager.transform.position;
            dir.Normalize();
            enemyManager.rB.MovePosition(enemyManager.rB.position + (dir * enemyManager.root1Speed * Time.deltaTime));
        }

        public override void OnStateEnter(EnemyManager enemyManager)
        {
            enemyManager.ChangeSprite();
            Debug.Log("Raices 1");
        }
    }
}