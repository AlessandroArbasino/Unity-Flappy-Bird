using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EventManager.ChangeDifficulty += MusicSpeed;
    }

    private void MusicSpeed(DifficultyData difficulty)
    {
        audioSource.pitch = difficulty.musicSpeed;
    }

    private void OnDestroy()
    {
        EventManager.ChangeDifficulty -= MusicSpeed;
    }
}
