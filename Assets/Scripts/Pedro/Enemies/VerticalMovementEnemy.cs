using UnityEngine;

public class VerticalMovementEnemy : MonoBehaviour
{
    public float speed = 5f;
    public GameObject[] positions;
    private int currentPositionIndex = 0;

    void Update()
    {
        if (positions == null || positions.Length == 0) return;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, positions[currentPositionIndex].transform.position, step);

        if (Vector3.Distance(transform.position, positions[currentPositionIndex].transform.position) < 0.001f)
        {
            currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<LifeSystem>().TakeDamage();
        }
    }
}
