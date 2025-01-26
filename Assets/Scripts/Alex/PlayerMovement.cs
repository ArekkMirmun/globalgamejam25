using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad normal
    [SerializeField] private float sprintSpeed = 7f; // Velocidad al hacer sprint
    [SerializeField] private float maxSpeed = 5f; // Velocidad máxima permitida
    [SerializeField] private float slowDownFactor = 0; // Factor de ralentización
    [SerializeField] private Rigidbody2D rb; // Referencia al Rigidbody2D
    [SerializeField] private Light2D light; // Referencia a la luz del submarino
    [SerializeField] private bool isFreeze = false; // Controla si el movimiento está congelado
    [SerializeField] private AudioSource propellerSound; // Sonido de la hélice
    private Vector2 _movement; // Dirección del movimiento
    private bool isSprinting = false; // Controla si el jugador está haciendo sprint
    
    
    private void FixedUpdate()
    {
        if (isFreeze) return;
        
        // Reproduce el sonido de la hélice si se mueve
        if (_movement.magnitude > 0)
        {
            if (!propellerSound.isPlaying)
            {
                propellerSound.Play();
            }
        }
        else
        {
            //Fade out the sound
            propellerSound.volume -= 0.01f;
            if (propellerSound.volume <= 0)
            {
                propellerSound.Stop();
                propellerSound.volume = 0.2f;
            }
        }

        // Determina la velocidad en función de si está haciendo sprint o no
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        // Añade fuerza en la dirección del movimiento teniendo en cuenta el multiplicador de ralentización
        
        rb.AddForce(_movement * (currentSpeed - slowDownFactor), ForceMode2D.Impulse);

        // Limita la velocidad máxima
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        
        //Flips the player if going left
        if (_movement.x < 0)
        {
            transform.localScale = new Vector3(1.5f, -1.5f, 1.5f);
            //Rotate light to 0 0 0
            light.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (_movement.x > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            light.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    public void OnMove(InputValue value)
    {
        if (isFreeze) return;
        // Obtiene el input del jugador
        Vector2 input = value.Get<Vector2>();
        
        // Almacena la dirección del movimiento
        _movement = input;
    }

    public void OnSprint(InputValue value)
    {
        if (isFreeze) return;

        print(value.isPressed);
        isSprinting = value.isPressed;

        // Ajusta la velocidad máxima mientras está en sprint
        maxSpeed = isSprinting ? sprintSpeed : speed;
    }

    public void FreezeMovement()
    {
        isFreeze = true;
        rb.linearVelocity = Vector2.zero; // Detiene el movimiento
    }

    public void UnFreezeMovement()
    {
        isFreeze = false;
    }
    
    public bool IsFreeze()
    {
        return isFreeze;
    }
    
    public void SlowDown(float slowDownFactor)
    {
        this.slowDownFactor = slowDownFactor;
    }
    
    public void ResetSpeed()
    {
        slowDownFactor = 0;
    }
}