using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public Image coinBackground;
    public Image pearlBackground;
    public Image diamondBackground;
    public Image fosilBackground;
    public Image chestBackground;
    public GameObject winPanel;
    public GameObject oxygenPanel;
    public GameObject lifePanel;
    public GameObject collectablePanel;
    public Button playButton;
    
    public TextMeshProUGUI collectedText;
    
    private int _collectablesToWin = 5;
    private int _collected = 0;
    
    
    public void Win()
    {
        
        winPanel.SetActive(true);
        playButton.Select();
        
        CollectableController collectableController = CollectableController.Instance;
        
        oxygenPanel.SetActive(false);
        lifePanel.SetActive(false);
        collectablePanel.SetActive(false);
        
        if(collectableController == null)
        {
            Debug.LogError("CollectableController is null");
            return;
        }
        
        //Cheks all collectables to see if is collected, if not, it will change the background color more transparent
        if (!collectableController.IsCollected(CollectableType.Coins))
        {
            coinBackground.color = new Color(coinBackground.color.r, coinBackground.color.g, coinBackground.color.b, 0.5f);
        }
        if (!collectableController.IsCollected(CollectableType.Pearl))
        {
            pearlBackground.color = new Color(pearlBackground.color.r, pearlBackground.color.g, pearlBackground.color.b, 0.5f);
        }
        if (!collectableController.IsCollected(CollectableType.Diamond))
        {
            diamondBackground.color = new Color(diamondBackground.color.r, diamondBackground.color.g, diamondBackground.color.b, 0.5f);
        }
        if (!collectableController.IsCollected(CollectableType.Fosil))
        {
            fosilBackground.color = new Color(fosilBackground.color.r, fosilBackground.color.g, fosilBackground.color.b, 0.5f);
        }
        if (!collectableController.IsCollected(CollectableType.Chest))
        {
            chestBackground.color = new Color(chestBackground.color.r, chestBackground.color.g, chestBackground.color.b, 0.5f);
        }
        
        _collected = collectableController.GetCollectableCount();
        collectedText.text = _collected + "/" + _collectablesToWin;
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //get PlayerMovement component
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.FreezeMovement();
            Win();
        }
    }
    
    public bool IsMenuOpen()
    {
        return winPanel.activeSelf;
    }
}
