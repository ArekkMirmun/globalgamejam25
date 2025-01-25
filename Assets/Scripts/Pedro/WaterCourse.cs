using UnityEngine;

public class WaterCourse : MonoBehaviour
{
    public GameObject blockBarrier;
    public GameObject rockPoint;
    public GameObject bubbleGenerator;

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
            Destroy(bubbleGenerator);
            other.GetComponent<Transform>().position = rockPoint.transform.position;
        }

    }
}
