using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float xMovementForce;
    public float yMovementForce;

    public static event Action OnMove;
    public static event Action OnDeath;
    public static event Action OnPointScored;
    public static event Action<int> OnDifficuiltyCheck;

    private float maximumVelocity;

    private void Awake()
    {
        StartGame.OnGameStarted += StartMovement;
        DifficultyManager.OnChangeDifficulty += SetVelocity;
        NewGameButtonScript.OnNewGame += ResetForce;
        OnDeath += ResetAvailableMovement;
    }
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.simulated = false;
        OnDifficuiltyCheck?.Invoke(0);
    }

    private void OnFly()
    {
        OnMove?.Invoke();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TubeSeparation")) 
            OnPointScored?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeath?.Invoke();
    }
    private void ResetForce()
    {
        rb.velocity = Vector3.zero;
    }

    private void SetVelocity(DifficultyValues currentDifficulty)
    {
        maximumVelocity = currentDifficulty.maxSpeed;
    }

    private void StartMovement()
    {
        OnMove += Move;
        rb.simulated = true;
    }

    private void ResetAvailableMovement()
    {
        rb.simulated = false;
        OnMove -= Move;
    }

    private void OnDestroy()
    {
        StartGame.OnGameStarted -= StartMovement;
        DifficultyManager.OnChangeDifficulty -= SetVelocity;
        NewGameButtonScript.OnNewGame -= ResetForce;
        OnDeath -= ResetAvailableMovement;
    }
}
