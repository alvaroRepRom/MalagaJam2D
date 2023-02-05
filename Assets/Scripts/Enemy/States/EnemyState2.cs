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
            ChangeSprite(enemyManager);
            Debug.Log("Raices 2");
        }
        
        public void ChangeSprite(EnemyManager enemyManager)
        {
            enemyManager.brote1.SetActive(false);
            enemyManager.brote2.SetActive(true);
            enemyManager.raices.SetActive(false);
        }
    }
}
