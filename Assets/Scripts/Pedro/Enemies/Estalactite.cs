using UnityEngine;

public class Estalactite : MonoBehaviour
{
    public float raycastDistance = 10f;
    public float fallSpeed = 5f; 
    public LayerMask playerLayer;

    public bool isFalling = false;

    void Update()
    {
        if (!isFalling)
        {
            // Lanza un raycast hacia abajo
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, playerLayer))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Player"))
                {
                    print("Hit player!");
                    isFalling = true;
                }
            }
        }
        else
        {
            // Si está cayendo, mueve la estalactita hacia abajo
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isFalling)
        {
            if (collision.gameObject.CompareTag("Player")) {
                collision.gameObject.GetComponent<LifeSystem>().TakeDamage();
            }
            
            if (collision.gameObject.CompareTag("Obstacle")) {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el raycast en la escena para depuración
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance);
    }
}
