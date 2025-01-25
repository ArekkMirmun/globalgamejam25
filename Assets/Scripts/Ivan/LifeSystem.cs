using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] healthUI; // Array para los corazones en la UI
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public int maxLifes = 3;
    public int health = 3;

    // Vida actual
    private int currentLife;

    void Start()
    {
        currentLife = health; // Inicializar la vida actual con la salud inicial
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health -= 1;
            healthUI[health].GetComponent<Image>().sprite = emptyHeart;
        }

        if (health == 0)
        {
            Die();
        }
    }

    public void AddLife(int life)
    {
        if (health < maxLifes)
        {
            print(health);
            health += life;
            if (health > maxLifes)
            {
                health = maxLifes;
            }


            // Actualizar el corazón correspondiente
            for (int i = 0; i < health; i++)
            {
                healthUI[i].GetComponent<Image>().sprite = fullHeart;
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
