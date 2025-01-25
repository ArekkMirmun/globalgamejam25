using UnityEngine;

public class WaterCourse : MonoBehaviour
{
    public GameObject blockBarrier;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
            }
        }

        if (other.CompareTag("Rock"))
        {
            Destroy(this.gameObject);
            Destroy(blockBarrier);
        }

    }
}
