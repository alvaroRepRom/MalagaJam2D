using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionKey;

    private List<GameObject> _enemiesInSight = new();
    public bool _isInteracting; //Esta variable se usará para evitar bugs de interacción al estar ya dialogando con un enemigo.

    private void Update()
    {
        if (Input.GetKeyDown(_interactionKey) && CanInteract())
        {
            Interact();
        }
    }

    private void Interact()
    {
        EnemyManager eM = _enemiesInSight[0].GetComponent<EnemyManager>();
        if (eM == null || eM._rootValue == 3) return;
        //Interactuamos con el primer enemigo de la lista.
        _isInteracting = true;
        eM.ActiveDialogue();
        Debug.Log($"Interactuando con {_enemiesInSight[0].name}");
    }

    private bool CanInteract()
    {
        //Podra interactuar si hay enemigos en la lista y si no esta interactuando.
        return _enemiesInSight.Count > 0 && !_isInteracting;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si hay un NPC en el rango
        if (other.CompareTag("Enemy"))
        {
            _enemiesInSight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Buscamos en la lista al enemigo y lo quitamos.
        if (other.CompareTag("Enemy"))
        {
            _enemiesInSight.Remove(other.gameObject);
        }
    }
}
