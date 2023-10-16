using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerMovement.OnPointScored += PlaySound;
    }

    private void PlaySound()
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {
        PlayerMovement.OnPointScored -= PlaySound;
    }
}
