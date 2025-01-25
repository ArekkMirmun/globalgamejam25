using TMPro;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectableText;
    private int _collectableCount = 0;

    //Booleans for all type of collectable
    private bool _hasCoins;
    private bool _hasFosil;
    private bool _hasPearl;
    private bool _hasDiamond;

    public void Collect(CollectableType collectableType)
    {
        switch (collectableType)
        {
            case CollectableType.Coins:
                _hasCoins = true;
                break;
            case CollectableType.Fosil:
                _hasFosil = true;
                break;
            case CollectableType.Pearl:
                _hasPearl = true;
                break;
            case CollectableType.Diamond:
                _hasDiamond = true;
                break;
        }
        
        IncrementCollectableText();
    }   
    
    private void IncrementCollectableText()
    {
        _collectableCount++;
        collectableText.text = _collectableCount.ToString();
    }
}
