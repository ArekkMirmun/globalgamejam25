using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad normal
    [SerializeField] private float sprintSpeed = 7f; // Velocidad al hacer sprint
    [SerializeField] private float maxSpeed = 5f; // Velocidad máxima permitida
    [SerializeField] private Rigidbody2D rb; // Referencia al Rigidbody2D
    [SerializeField] private bool isFreeze = false; // Controla si el movimiento está congelado
    private Vector2 _movement; // Dirección del movimiento
    private bool isSprinting = false; // Controla si el jugador está haciendo sprint
    
    private void FixedUpdate()
    {
        if (isFreeze) return;

        // Determina la velocidad en función de si está haciendo sprint o no
        float currentSpeed = isSprinting ? sprintSpeed : speed;
        print(currentSpeed);

        // Añade fuerza en la dirección del movimiento
        rb.AddForce(_movement * currentSpeed, ForceMode2D.Impulse);

        // Limita la velocidad máxima
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
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
}
