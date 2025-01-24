using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{

    [Header("Configuracion")]
    [SerializeField] private int maxLifes = 3; // Número de vidas
    [SerializeField] private float separation = 10f; // Separación entre las vidas
    [SerializeField] private float size = 50f; // Tamaño de la vida

    [Header("Referencias")]
    [SerializeField] private GameObject parentLife; // Padre de las vidas
    [SerializeField] private Sprite lifeImage; // Imagen de la vida
    [SerializeField] private Sprite emptyLifeImage; // Puede estar vacio o no

    private GameObject[] lifes; // Para facilitar la vida en la gestión de la vida

    private int currentLife; // Vida actual

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLifes;
        lifes = new GameObject[maxLifes];

        for (int i = 0; i < maxLifes; i++)
        {
            // Crea un objeto vacio
            GameObject life = Instantiate(new GameObject(), parentLife.transform);
            // Se le cambia el padre
            life.transform.SetParent(parentLife.transform);
            // Añade un componente Image
            life.AddComponent<Image>().sprite = lifeImage;
            // Cambia el Width y Height
            life.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            // Cambia la posición añadiendo la separaciçon indicada en el inspector
            life.transform.localPosition = new Vector3(i * separation, 0, 0);
            lifes[i] = life;
        }
    }

    public void TakeDamage(int damage){
        currentLife -= damage;
        if(currentLife <= 0){
            currentLife = 0;
            Debug.Log("Has morido");
        }
        UpdateLife();
    }

    public void AddLife(int life){
        currentLife += life;
        if(currentLife > maxLifes){
            currentLife = maxLifes;
            Debug.Log("Llevas demasiadas vidas");
        }
        UpdateLife();
    }

    private void UpdateLife(){
        for (int i = 0; i < maxLifes; i++)
        {
            if (i < currentLife)
            {
                if(emptyLifeImage != null){
                    lifes[i].GetComponent<Image>().sprite = lifeImage;
                }else{
                    lifes[i].SetActive(true);
                }
            }
            else
            {
                if(emptyLifeImage != null){
                    lifes[i].GetComponent<Image>().sprite = emptyLifeImage;
                }else{
                    lifes[i].SetActive(false);
                }
            }
        }
    }
}
