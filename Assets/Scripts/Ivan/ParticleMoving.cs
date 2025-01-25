using UnityEngine;

public class ParticleMoving : MonoBehaviour
{
    [Header("Particle configuration")]
    [SerializeField] private float minEmision = 1f;
    [SerializeField] private float maxEmision = 1f;
    [SerializeField] private ParticleSystem particleSystem;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rb.linearVelocity.magnitude > 0)
        {
            var emission = particleSystem.emission;
            emission.rateOverTime = maxEmision;
        }
        else
        {
            var emission = particleSystem.emission;
            emission.rateOverTime = minEmision;
        }
    }
}
