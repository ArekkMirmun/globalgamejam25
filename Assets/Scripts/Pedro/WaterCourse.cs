using UnityEngine;

public class WaterCourse : MonoBehaviour
{
    public GameObject blockBarrier;
    public GameObject rock;
    public GameObject bubbleGenerator;
    public AudioSource rockPlaceSound;
    public float respulsionForce = 50f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.left * respulsionForce, ForceMode2D.Impulse);
            }
        }

        if (other.CompareTag("Rock"))
        {
            rockPlaceSound.Play();
            Destroy(other.transform.parent.gameObject);
            Destroy(blockBarrier);
            Destroy(bubbleGenerator);
            rock.SetActive(true);
        }
    }
}
