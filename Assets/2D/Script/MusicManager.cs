using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DifficultyManager.OnChangeDifficulty += MusicSpeed;
    }

    private void MusicSpeed(DifficultyValues difficulty)
    {
        audioSource.pitch = difficulty.musicSpeed;
    }

    private void OnDestroy()
    {
        DifficultyManager.OnChangeDifficulty -= MusicSpeed;
    }
}
