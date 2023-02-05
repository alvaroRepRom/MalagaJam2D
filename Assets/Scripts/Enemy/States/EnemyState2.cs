using UnityEngine;

namespace Enemy
{
    public class EnemyState2 : EnemyState
    {
        public override void Execute(EnemyManager enemyManager)
        {
            //Movimiento random dentro de la Party Zone con la velocidad root2
            if (enemyManager.interacting) return;
        }

        public override void OnStateEnter(EnemyManager enemyManager)
        {
            enemyManager.ChangeSprite();
            Debug.Log("Raices 2");
        }
    }
}
