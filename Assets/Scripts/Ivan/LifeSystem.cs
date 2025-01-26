using System;
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
    public SpriteRenderer submarineSprite;
    private float invencibilityTime = 1f; // Tiempo de invencibilidad
    private float invencibilityTimer; // Temporizador de invencibilidad
    private bool isInvencible; // Indica si el jugador es invencible
    private CameraShake cameraShake;

    // Vida actual
    private int currentLife;

    private void FixedUpdate()
    {
        if (isInvencible)
        {
            //Get PlayerMovement component
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            //Slow down the player
            playerMovement.SlowDown(5f);  
            invencibilityTimer += Time.deltaTime;
            if (invencibilityTimer >= invencibilityTime)
            {
                isInvencible = false;
                submarineSprite.color = Color.white;
                invencibilityTimer = 0f;
                playerMovement.ResetSpeed();
            }
        }
    }


    void Start()
    {
        currentLife = health; // Inicializar la vida actual con la salud inicial
        cameraShake = GetComponent<CameraShake>();
    }

    public void TakeDamage()
    {
        if (isInvencible) return;

        cameraShake.ShakeCamera(1f, 0.8f);
        
        isInvencible = true;
        
        //set submarine sprite red
        submarineSprite.color = Color.red;
        
        if (health > 0)
        {
            health -= 1;
            healthUI[health].GetComponent<Image>().sprite = emptyHeart;
            //set the player invencible
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
