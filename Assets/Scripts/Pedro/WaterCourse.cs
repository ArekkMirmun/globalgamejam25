using UnityEngine;

public class WaterCourse : MonoBehaviour
{
    public GameObject blockBarrier;
    public GameObject rockPoint;
    public GameObject bubbleGenerator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            Destroy(this.gameObject);
            Destroy(blockBarrier);
            Destroy(bubbleGenerator);
            other.GetComponent<Transform>().position = rockPoint.transform.position;
            Rigidbody2D rockRigidbody = other.GetComponent<Rigidbody2D>();
            if (rockRigidbody != null)
            {
                rockRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            Collider2D rockCollider = other.GetComponent<Collider2D>();
            if (rockCollider != null)
            {
                rockCollider.enabled = true;
            }
        }

    }
}
