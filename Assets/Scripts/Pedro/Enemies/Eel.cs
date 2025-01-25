using UnityEngine;

public class Eel : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Transform targetPoint; // Punto al que se moverá la Eel
    private bool isMoving = false; // Controla si la Eel está en movimiento
    private EelManager eelManager; // Referencia al controlador de las anguilas

    void Start()
    {
        eelManager = FindFirstObjectByType<EelManager>(); // Encuentra el controlador en la escena
    }

    public void StartMoving(Transform movementPoint)
    {
        if (eelManager != null)
        {
            eelManager.ActivateEel(this); // Notifica al controlador para activar esta Eel
        }

        targetPoint = movementPoint;
        isMoving = true;
    }

    public void StopMoving()
    {
        targetPoint = null;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving && targetPoint != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.001f)
            {
                isMoving = false;
                targetPoint = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<LifeSystem>().TakeDamage();
        }
    }
}
