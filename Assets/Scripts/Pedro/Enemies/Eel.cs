using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public List<Transform> pathPoints; // Lista de puntos que forman el camino
    private int currentPointIndex = 0; // Índice del punto actual en la ruta
    private bool isMoving = false; // Controla si la Eel está en movimiento
    private EelManager eelManager; // Referencia al controlador de las anguilas

    void Start()
    {
        eelManager = FindFirstObjectByType<EelManager>(); // Encuentra el controlador en la escena

        // Asegurarse de que haya al menos un punto en la ruta
        if (pathPoints.Count > 0)
        {
            transform.position = pathPoints[0].position; // Posicionar la anguila en el primer punto
        }
    }

    public void StartMoving()
    {
        if (eelManager != null)
        {
            eelManager.ActivateEel(this); // Notifica al controlador para activar esta Eel
        }

        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    void Update()
    {
        if (isMoving && pathPoints.Count > 0)
        {
            // Moverse hacia el punto actual
            Transform targetPoint = pathPoints[currentPointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

            // Verificar si se alcanzó el punto actual
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.001f)
            {
                // Avanzar al siguiente punto, reiniciando el índice si llega al final
                currentPointIndex = (currentPointIndex + 1) % pathPoints.Count;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<LifeSystem>().TakeDamage();
        }
    }
}
