using UnityEngine;

public class BubbleFX : MonoBehaviour
{
    [Header("Ajustes FX de la burbuja")]
    [SerializeField] private float minSpeed = 1f; // La velocidad minima de la burbuja
    [SerializeField] private float maxSpeed = 1f; // La velocidad maxima de la burbuja
    [SerializeField] private float bubbleLifeTime = 6f; // El tiempo de vida de la burbuja
    [SerializeField] private float xSpeed = 0.01f; // La oscilación en el eje X de la burbuja (Movimiento en horizontal)
    [SerializeField] private bool inverseY = false; // Invertir el movimiento en Y
    
    private float timeXMove; // El tiempo de oscilación en el eje X de la burbuja
    private float speed; // La velocidad de la burbuja

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed); // Obtiene una velocidad aleatoria
        timeXMove = Random.Range(1f, 2f); // Obtiene un tiempo de oscilación aleatorio
        Destroy(gameObject, bubbleLifeTime); // Elimina la burbuja después de tiempo de vida
    }

    void Update()
    {
        // Mueve la burbuja hacia arriba oscilando su posición en el eje X para darle un efecto de burbuja
        if(!inverseY)
            transform.position += new Vector3(Mathf.Sin(Time.time * timeXMove) * xSpeed, speed * Time.deltaTime, 0f);
        else
            transform.position -= new Vector3(Mathf.Sin(Time.time * timeXMove) * xSpeed, speed * Time.deltaTime, 0f);
    }


}
