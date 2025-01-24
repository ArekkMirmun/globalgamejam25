using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _movement;
    
    private void FixedUpdate()
    {
        // Add the movement registered by the player with an impulse to the direction registered
        rb.AddForce(_movement * speed, ForceMode2D.Impulse);

        // Limit the maximum speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }



    public void OnMove(InputValue value)
    {
        //Get the input from the player
        Vector2 input = value.Get<Vector2>();
        
        //Set the movement to the input
        _movement = input;
    }
}
