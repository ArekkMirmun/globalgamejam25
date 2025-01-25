using UnityEngine;


public enum ControllerType
{
    Keyboard,
    Gamepad
}
public class Interactable : MonoBehaviour
{
 
    public  Sprite keyboardKey;
    public Sprite gamepadKey;
    [SerializeField] private InteractableType interactableType;
    [SerializeField] private bool isUsed;
    [SerializeField] private GameObject keyHint;

    #region OnTrigger functions

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isUsed) return;
        if (other.CompareTag("Player"))
        {
            keyHint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isUsed) return;
        if (other.CompareTag("Player"))
        {
            keyHint.SetActive(false);
        }
    }

    #endregion
    
    public void Interact()
    {
        if(isUsed) return;
        
        isUsed = true;
        
        keyHint.SetActive(false);
        
        switch (interactableType)
        {
            case InteractableType.Collectable:
                //Get the collectable component
                Collectable collectable = GetComponent<Collectable>();
                //Call the interact method from the collectable component
                collectable.Interact();
                break;
            case InteractableType.Rock:
                //Get the rock component
                Rock rock = GetComponent<Rock>();
                //Call the interact method from the rock component
                rock.Interact();
                break;
            case InteractableType.Rune:
                //Get the rune component
                Rune rune = GetComponent<Rune>();
                //Call the interact method from the rune component
                rune.Interact();
                break;
            case InteractableType.Chest:
                //Get the chest component
                Chest chest = GetComponent<Chest>();
                //Call the interact method from the chest component
                chest.Interact();
                break;
        }
    }
    
    public bool IsUsed()
    {
        return isUsed;
    }
    
    public void SetIsUsed(bool value)
    {
        isUsed = value;
    }

    public void ChangeKeyHint(ControllerType controllerType)
    {
        switch (controllerType)
        {
            case ControllerType.Keyboard:
                keyHint.GetComponent<SpriteRenderer>().sprite = keyboardKey;
                break;
            case ControllerType.Gamepad:
                keyHint.GetComponent<SpriteRenderer>().sprite = gamepadKey;
                break;
        }
    }
}
