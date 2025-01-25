using UnityEngine;

public class RuneController : MonoBehaviour
{
    private int _runeToUnlock = 3;
    [SerializeField] private Chest chest;
    
    
    public void Collect()
    {
        _runeToUnlock--;
        if (_runeToUnlock == 0)
        {
            chest.Unlock();
        }
    }
}
