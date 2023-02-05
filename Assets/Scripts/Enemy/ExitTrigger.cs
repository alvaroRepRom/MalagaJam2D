using UnityEngine;

namespace Enemy
{
    public class ExitTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            //Si un enemigo entra en la salida lo destruimos (ejecutamos animacion primero si se desea) y quitamos uno en peopleleft.
            if (col.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyManager>().StopRunning();
                Destroy(col.gameObject);
                GameManager.Instance.NPCHasLeftRoom();
            }
        }
    }
}
