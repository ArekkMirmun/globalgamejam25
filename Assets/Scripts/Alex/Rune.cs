using UnityEngine;

public class Rune : MonoBehaviour
{
    [SerializeField] private GameObject chains;
    [SerializeField] private RuneController runeController;
    [SerializeField] private GameObject runeLight;
    [SerializeField] private Sprite activatedSprite;



    #region Interact function
    
    public void Interact()
    {
        runeController.Collect();
        Destroy(chains);
        runeLight.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = activatedSprite;
        
    }

    #endregion
}
