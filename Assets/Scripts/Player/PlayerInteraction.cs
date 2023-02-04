using Enemy;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionKey;

    private GameObject _currentNPC;
    private bool _canInteract;

    private void Update()
    {
        if (Input.GetKeyDown(_interactionKey) && _canInteract)
        {
            Interact();
        }
    }

    private void Interact()
    {
        //Si no hay ningún NPC en la variable, salimos del metodo.
        if (!_currentNPC) return;
        Debug.Log("Interactuando");
        _currentNPC.GetComponent<EnemyManager>().ActiveDialogue();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si hay un NPC en el rango
        if (other.CompareTag("NPC"))
        {
            //Hacemos que pueda interactuar y guardamos al NPC en una variable.
            _canInteract = true;
            _currentNPC = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Comprobamos si el NPC que sale es el mismo con el que podemos interactuar ahora mismo. Si es asi, dejamos de interactuar.
        if (other.CompareTag("NPC") && other.gameObject == _currentNPC)
        {
            _canInteract = false;
            _currentNPC = null;
        }
    }
}
