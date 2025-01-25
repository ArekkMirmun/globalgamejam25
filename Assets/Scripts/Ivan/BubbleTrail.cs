using UnityEngine;

public class BubbleTrail : MonoBehaviour
{
    [Header("Ajustes de la aparición de burbujas")]
    [SerializeField] private GameObject[] bubbleTrailPrefab; // Prefabs de la/s burbuja/s
    [SerializeField] private float bubbleTrailSpawnRate = 3f; // La tasa de generación de burbujas
    [SerializeField] private float bubbleTrailSpawnRateOnMove = 0.1f; // La tasa de generación de burbujas cuando se mueve el ratón

    private float spawnRate = 0f; // La tasa de generación de burbujas
    private Vector3 mousePosition; // La posición del ratón
    private Vector3 lastMousePosition; // La última posición del ratón

    void Start(){
        lastMousePosition = Input.mousePosition;
    }

    void Update(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        if (Input.mousePosition != lastMousePosition)
        {
            spawnRate += Time.deltaTime;
            if(spawnRate >= bubbleTrailSpawnRateOnMove){
                spawnRate = 0f;
                SpawnBubbleTrail();
            }
        }
        else
        {
            spawnRate += Time.deltaTime;
            if(spawnRate >= bubbleTrailSpawnRate){
                spawnRate = 0f;
                SpawnBubbleTrail();
            }
        }

        lastMousePosition = Input.mousePosition;
    }

    void SpawnBubbleTrail(){
        int randomIndex = Random.Range(0, bubbleTrailPrefab.Length);
        GameObject bubbleTrail = Instantiate(bubbleTrailPrefab[randomIndex], mousePosition, Quaternion.identity);
    }

}
