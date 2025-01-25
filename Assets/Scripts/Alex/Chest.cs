using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chest : MonoBehaviour
{
    [SerializeField] private bool _isLocked;
    [SerializeField] private Interactable _interactable;
    [SerializeField] private Sprite openChestSprite;
    [SerializeField] private Light2D light2D;

    public void Interact()
    {
        if (_isLocked) return;
        
        //Get sprite renderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //Change the sprite to the open chest sprite
        spriteRenderer.sprite = openChestSprite;
        //Enable the light
        light2D.gameObject.SetActive(true);
        
        //TODO: ADD end cinematic

    }

    public void Unlock()
    {
        
        _isLocked = false;
        _interactable.SetIsUsed(false);
    }
}
