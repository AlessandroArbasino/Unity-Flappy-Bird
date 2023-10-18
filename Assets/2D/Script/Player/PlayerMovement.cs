using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float xMovementForce;
    public float yMovementForce;

    private float maximumVelocity;
    private PlayerInput input;

    private void Awake()
    {
        EventManager.GameStarted += StartMovement;
        EventManager.ChangeDifficulty += SetVelocity;
        EventManager.NewGame += ResetForce;
        EventManager.Death += ResetAvailableMovement;
    }
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.simulated = false;
        EventManager.OnDifficuiltyCheck(0);

        input = new PlayerInput();
        input.Enable();

        input.Player.Fly.started += OnFly;
    }
    private void OnDestroy()
    {
        EventManager.GameStarted -= StartMovement;
        EventManager.ChangeDifficulty -= SetVelocity;
        EventManager.NewGame -= ResetForce;
        EventManager.Death -= ResetAvailableMovement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TubeSeparation")) 
            EventManager.OnPointScored();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventManager.OnDeath();
    }

    private void OnFly(InputAction.CallbackContext context)
    {
        EventManager.OnMove();
    }
    private void Move()
    {
        rb.AddForce(new Vector3(.5f, 5, 0), ForceMode2D.Impulse);

        if (rb.velocity.x >= maximumVelocity)
        {
            Vector2 clampedVector = new Vector2(Mathf.Clamp(rb.velocity.x, -1, maximumVelocity), rb.velocity.y);
            rb.velocity = clampedVector;
        }
        
    }

    private void ResetForce()
    {
        rb.velocity = Vector3.zero;
    }

    private void SetVelocity(DifficultyData currentDifficulty)
    {
        maximumVelocity = currentDifficulty.maxSpeed;
    }

    private void StartMovement()
    {
        EventManager.Move += Move;
        rb.simulated = true;
    }

    private void ResetAvailableMovement()
    {
        rb.simulated = false;
        EventManager.Move -= Move;
    }

}
