using UnityEngine;

public class Bubble : MonoBehaviour
{
    private OxygenSystem oxygenSystem;
    public float oxygenRecoveryRate = 1f;

    void Start()
    {
        oxygenSystem = FindFirstObjectByType<OxygenSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oxygenSystem.AddOxygen(oxygenRecoveryRate);
            Destroy(gameObject);
        }
    }
}
