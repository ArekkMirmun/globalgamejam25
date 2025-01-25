using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private bool _isLocked;
    [SerializeField] private Interactable _interactable;

    public void Interact()
    {
        if (_isLocked) return;
        
        //Open the chest
        //TODO: Add logic to open the chest
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

    }

    public void Unlock()
    {
        
        _isLocked = false;
        _interactable.SetIsUsed(false);
    }
}
