using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartGame.OnGameStarted += StartFly;
        PlayerMovement.OnDeath += ResetFlyPossibility;
    }

   private void PlayFly()
   {
        audioSource.Play();
        StartGame.OnGameStarted -= StartFly;
        PlayerMovement.OnDeath -= ResetFlyPossibility;
    }

    private void OnDestroy()
    {
        PlayerMovement.OnMove -= PlayFly;
    }

    private void StartFly()
    {
        PlayerMovement.OnMove += PlayFly;
    }

    private void ResetFlyPossibility()
    {
        PlayerMovement.OnMove -= PlayFly;
    }
}
