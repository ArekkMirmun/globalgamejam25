using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public Image coinBackground;
    public Image pearlBackground;
    public Image diamondBackground;
    public Image fosilBackground;
    
    public TextMeshProUGUI collectedText;
    
    private int _collectablesToWin = 4;
    private int _collected = 0;


    public void Start()
    {
        CollectableController collectableController = CollectableController.Instance;
        
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
        
        _collected = collectableController.GetCollectableCount();
        collectedText.text = _collected + "/4";
        
    }
}
