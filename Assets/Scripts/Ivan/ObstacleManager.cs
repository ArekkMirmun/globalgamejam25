using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Obstacle Manager")]
    [SerializeField] private float pushForce = 1f; // Fuerza de empuje multiplicada

    private Rigidbody2D rb;
    private LifeSystem lifeSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeSystem = FindFirstObjectByType<LifeSystem>();
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
            
            rb.AddForce(pushDirection, ForceMode2D.Impulse); // Hace que el jugador se impulse hacia el lado contrario del choque
        }
    }
}
