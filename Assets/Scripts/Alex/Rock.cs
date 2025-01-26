using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private GameObject chainedRock;
    [SerializeField] private GameObject supportRock;
    
    public void Interact()
    {
        chainedRock.SetActive(true);
        
        //destroy this rock
        Destroy(gameObject);
        
        //Disable collider and of the support rock
        supportRock.GetComponent<Collider2D>().enabled = false;
    }
}
