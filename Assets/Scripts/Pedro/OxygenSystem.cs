using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{
    public float oxygen = 100f;
    public float maxOxygen = 100f;
    public float oxygenDepletionRate = 1f;
    public float movingDepletionMultiplier = 2f;
    public GameObject oxygenSliderUI;
    public PlayerMovement playerMovement;

    private Vector2 _movement;


    void Start()
    {
         oxygenSliderUI.GetComponent<Slider>().value = oxygen;
         playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(playerMovement.IsFreeze()) return;
        
        bool isMoving = _movement != Vector2.zero;

        float depletionRate = isMoving ? oxygenDepletionRate * movingDepletionMultiplier : oxygenDepletionRate;

        // Reducir el oxígeno con base en la tasa de consumo
        oxygen -= depletionRate * Time.deltaTime;
        oxygenSliderUI.GetComponent<Slider>().value = oxygen;

        // Asegurarse de que el oxígeno no baje de 0
        oxygen = Mathf.Clamp(oxygen, 0, maxOxygen);

        // Opcional: Detectar si el oxígeno llega a 0
        if (oxygen <= 0)
        {
            //Get lifesystem component
            LifeSystem lifeSystem = GetComponent<LifeSystem>();
            //Take damage
            lifeSystem.TakeDamage();
            AddOxygen(20);
        }
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    public void AddOxygen(float amount)
    {
        oxygen += amount;
        oxygen = Mathf.Clamp(oxygen, 0, maxOxygen);
        Debug.Log($"Oxígeno añadido. Nivel actual: {oxygen}/{maxOxygen}");
    }
}
