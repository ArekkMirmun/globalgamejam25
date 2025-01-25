using UnityEngine;
using UnityEngine.InputSystem;

public class DetectController : MonoBehaviour
{
    private PlayerInput playerInput; // Referencia al PlayerInput
    private string currentControlScheme; // Esquema de control actual

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        currentControlScheme = playerInput.currentControlScheme;
    }

    void OnEnable()
    {
        playerInput.onControlsChanged += OnControlsChanged;
    }

    void OnDisable()
    {
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    private void OnControlsChanged(PlayerInput input)
    {
        currentControlScheme = input.currentControlScheme;

        if (currentControlScheme == "Gamepad")
        {
            //Access all interactable by type objects and change the sprite to gamepadKey
            Interactable[] interactables = FindObjectsByType<Interactable>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (Interactable interactable in interactables)
            {
                interactable.ChangeKeyHint(ControllerType.Gamepad);
            }
            
            
        }
        
        if (currentControlScheme == "Keyboard&Mouse")
        {
            //Access all interactable by type objects and change the sprite to keyboardKey
            Interactable[] interactables = FindObjectsByType<Interactable>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (Interactable interactable in interactables)
            {
                interactable.ChangeKeyHint(ControllerType.Keyboard);
            }
        }
    }
}