using TMPro;
using UnityEngine;


public class CollectableController : MonoBehaviour
{
    public static CollectableController Instance;
    
    [SerializeField] private TextMeshProUGUI collectableText;
    private int _collectableCount = 0;

    //Booleans for all type of collectable
    private bool _hasCoins;
    private bool _hasFosil;
    private bool _hasPearl;
    private bool _hasDiamond;
    private bool _hasChest;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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
            case CollectableType.Chest:
                _hasChest = true;
                break;
        }
        
        IncrementCollectableText();
    }   
    
    private void IncrementCollectableText()
    {
        _collectableCount++;
        collectableText.text = _collectableCount.ToString();
    }

    public bool IsCollected(CollectableType collectableType)
    {
        switch (collectableType)
        {
            case CollectableType.Coins:
                return _hasCoins;
            case CollectableType.Fosil:
                return _hasFosil;
            case CollectableType.Pearl:
                return _hasPearl;
            case CollectableType.Diamond:
                return _hasDiamond;
            case CollectableType.Chest:
                return _hasChest;
        }

        return false;
    }
    
    public int GetCollectableCount()
    {
        return _collectableCount;
    }
}
