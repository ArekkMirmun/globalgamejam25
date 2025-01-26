using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject buttonWrapper;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Button playButton;
    [SerializeField] private Transform player;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private GameObject oxygenCanvas;
    [SerializeField] private GameObject lifeCanvas;
    [SerializeField] private GameObject treasureCanvas;
    public bool isVisible = true;

    private bool isStartingGame = false;

    private void Start()
    {
        ShowMenu();
    }

    private void Update()
    {
        if (isStartingGame)
        {
            // Smoothly move the player to x:0
            player.position = Vector3.Lerp(player.position, new Vector3(0, player.position.y, player.position.z), Time.deltaTime);

            // Check if the player is close enough to the target position
            if (Mathf.Abs(player.position.x) < 0.4f)
            {
                CompleteStartGame();
            }
        }
    }

    public void ShowMenu()
    {
        // Set the menu to visible
        isVisible = true;

        // Freeze the player movement
        playerMovement.FreezeMovement();

        // Remove tracking target from the player camera
        playerCamera.Follow = null;

        // Set the button wrapper to active
        buttonWrapper.SetActive(true);

        // Set the play button to be selected
        playButton.Select();
    }

    public void HideMenu()
    {
        isVisible = false;
        playerMovement.UnFreezeMovement();
        buttonWrapper.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        buttonWrapper.SetActive(false);
        isStartingGame = true; // Start the game logic
    }

    private void CompleteStartGame()
    {
        isStartingGame = false; // Stop moving the player
        
        // Show the UI elements
        oxygenCanvas.SetActive(true);
        lifeCanvas.SetActive(true);
        treasureCanvas.SetActive(true);

        Debug.Log("Ha llegado");

        // Unfreeze player movement
        playerMovement.UnFreezeMovement();

        // Set the player camera to follow the player
        playerCamera.Follow = player;

        // Set the menu to invisible
        HideMenu();
    }

    public bool IsMenuOpen()
    {
        return isVisible;
    }
}
