using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Obstacle Manager")]
    [SerializeField] private float minPushForce = 1f; // Fuerza de empuje multiplicada
    [SerializeField] private float maxPushForce = 2f; // Fuerza de empuje multiplicada
    [SerializeField] private float multiplierPushForce = 2f; // Multiplicador de fuerza de empuje

    private Rigidbody2D rb;
    private LifeSystem lifeSystem;

    private float previousVelocity = 0;
    private float lastVelocity = 0; 
    private float pushForce = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeSystem = FindFirstObjectByType<LifeSystem>();
    }

    void Update(){
        previousVelocity = lastVelocity; // Guarda la velocidad anterior
        lastVelocity = rb.linearVelocity.magnitude; // Obtiene la velocidad actual
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            lifeSystem.TakeDamage();

            // Cuando choca deberia de añadirse una fuerza hacia atras
            // de donde viene la colision
            // para que el jugador no se quede pegado al obstaculo
            // y exista una sensacion de impacto

            // Posición de la colisión
            Vector3 collisionPosition = collision.contacts[0].point;

            // Direccion de empuje
            Vector2 pushDirection = (transform.position - collisionPosition).normalized;

            // Ajusta la velocidad de empuje
            pushForce = lastVelocity * multiplierPushForce; 
            if(pushForce < minPushForce)
                pushForce = minPushForce;
            else if(pushForce > maxPushForce)
                pushForce = maxPushForce;

            Debug.Log("Push Force: " + pushForce);
            
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Hace que el jugador se impulse hacia el lado contrario del choque
        }
    }
}
