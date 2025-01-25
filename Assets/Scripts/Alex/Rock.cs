using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private GameObject chainedRock;
    
    public void Interact()
    {
        chainedRock.SetActive(true);
        
        //destroy this rock
        Destroy(gameObject);
    }
}
