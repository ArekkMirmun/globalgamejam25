using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    public GameObject bubblePrefab; // Prefab de la burbuja
    public float spawnRangeX = 1f; // Rango en X para generar burbujas
    public float spawnHeight = 0f; // Altura fija para las burbujas
    public float spawnInterval = 2f; // Intervalo de generación en segundos

    private float _spawnTimer;
    private int _currentBubbleCount;

    void Update()
    {
        // Contador para generar burbujas según el intervalo
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval)
        {
            SpawnBubble();
            _spawnTimer = 0f; // Reiniciar el temporizador
        }
    }

    private void SpawnBubble()
    {
        // Generar una posición aleatoria solo en X dentro del rango relativo a la posición del generador
        float xPos = Random.Range(-spawnRangeX, spawnRangeX) + transform.position.x;
        Vector3 spawnPosition = new Vector3(xPos, spawnHeight + transform.position.y, 0f);

        // Instanciar la burbuja
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        _currentBubbleCount++;

    }

    private void HandleBubbleDestroyed()
    {
        _currentBubbleCount--;
    }
}
