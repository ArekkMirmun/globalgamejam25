using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{

    [Header("Configuracion")]
    [SerializeField] private int maxLifes = 3;
    [SerializeField] private float separation = 10f;

    [Header("Referencias")]
    [SerializeField] private GameObject parentBackground;
    [SerializeField] private GameObject parentLife;
    [SerializeField] private GameObject lifeImage;

    private GameObject[] background;
    private GameObject[] lifes;

    private int currentLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLifes;
        background = new GameObject[maxLifes];
        lifes = new GameObject[maxLifes];

        for (int i = 0; i < maxLifes; i++)
        {
            background[i] = Instantiate(parentBackground, parentLife.transform);
            // Se pone como padre el parenBackground para que se vean en el mismo lugar
            
            background[i].transform.localPosition = new Vector3(i * separation, 0, 0);
            lifes[i] = Instantiate(lifeImage, background[i].transform);
        }
    }

    public void TakeDamage(int damage){
        
    }
}
