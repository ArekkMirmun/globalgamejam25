using UnityEngine;

public class BubbleFX : MonoBehaviour
{
    [Header("Ajustes FX de la burbuja")]
    [SerializeField] private float minSpeed = 1f; // La velocidad minima de la burbuja
    [SerializeField] private float maxSpeed = 1f; // La velocidad maxima de la burbuja
    [SerializeField] private float bubbleLifeTime = 6f; // El tiempo de vida de la burbuja
    [SerializeField] private float xSpeed = 0.01f; // La oscilación en el eje X de la burbuja (Movimiento en horizontal)
    
    private float timeXMove; // El tiempo de oscilación en el eje X de la burbuja
    private float speed; // La velocidad de la burbuja

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed); // Obtiene una velocidad aleatoria
        timeXMove = Random.Range(1f, 2f); // Obtiene un tiempo de oscilación aleatorio
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la burbuja hacia arriba oscilando su posición en el eje X para darle un efecto de burbuja
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * timeXMove) * xSpeed, transform.position.y + speed * Time.deltaTime, transform.position.z);
    }
}
