using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EventManager.GameStarted += StartFly;
        EventManager.Death += ResetFlyPossibility;
    }

   private void PlayFly()
   {
        audioSource.Play();
        EventManager.GameStarted -= StartFly;
        EventManager.Death -= ResetFlyPossibility;
    }

    private void OnDestroy()
    {
        EventManager.Move -= PlayFly;
    }

    private void StartFly()
    {
        EventManager.Move += PlayFly;
    }

    private void ResetFlyPossibility()
    {
        EventManager.Move -= PlayFly;
    }
}
