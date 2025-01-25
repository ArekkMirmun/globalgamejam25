using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject buttonWrapper;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private Button playButton;
    [SerializeField] private Transform player;
    [SerializeField] private CinemachineCamera playerCamera; 
    public bool isVisible = true;
    
    private void Start()
    {
        ShowMenu();
    }

    
    public void ShowMenu()
    {
        //set the menu to visible
        isVisible = true;
        
        //freeze the player movement
        playerMovement.FreezeMovement();
        
        //remove tracking target from the player camera
        playerCamera.Follow = null;
        
        //set the button wrapper to active
        buttonWrapper.SetActive(true);
        
        //set the play button to be selected
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
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        buttonWrapper.SetActive(false);
        
        //Move player to x:0 smoothly
        while (player.position.x < -0.4f)
        {
            player.position = Vector3.Lerp(player.position, new Vector3(0, player.position.y, player.position.z), Time.deltaTime);
            yield return null;
        }
        print("Ha llegado");

        //unfreeze player movement
        playerMovement.UnFreezeMovement();
        
        //set the player camera to follow the player
        playerCamera.Follow = player;
    }
    
}
