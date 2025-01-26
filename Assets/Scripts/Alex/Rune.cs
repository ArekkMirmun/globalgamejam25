using UnityEngine;

public class Rune : MonoBehaviour
{
    [SerializeField] private SpriteRenderer chainsRune;
    [SerializeField] private GameObject chainsLight;
    [SerializeField] private RuneController runeController;
    [SerializeField] private AudioSource runeSound;
    [SerializeField] private GameObject runeLight;
    [SerializeField] private Sprite activatedSprite;
    [SerializeField] private GameObject hingeToDestroy;



    #region Interact function
    
    public void Interact()
    {
        runeController.Collect();
        runeLight.SetActive(true);
        chainsLight.SetActive(true);
        runeSound.Play();
        
        Destroy(hingeToDestroy);
        GetComponent<SpriteRenderer>().sprite = activatedSprite;
        chainsRune.sprite = activatedSprite;
        
        
    }

    #endregion
}
