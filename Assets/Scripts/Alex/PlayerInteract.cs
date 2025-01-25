using UnityEngine;

public enum InteractableType
{
    Collectable,
    Rock,
    Rune,
    Chest
}

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Interactable interactable;

    public void OnInteract()
    {
        if (!interactable) return;
        
        interactable.Interact();
        
        interactable = null;
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            //Get the interactable component
            Interactable interactableObject = other.GetComponent<Interactable>();
            //Check if the interactable is already used
            if (interactableObject.IsUsed()) return;

            interactable = interactableObject;

        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactable = null;
        }
    }
}
