using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider= GetComponent<Slider>();
    }
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volumeSlider.value;
        }
        else
        {
            volumeSlider.value = 1;
        }
        
    }

    private void SetVolume()
    {
        AudioListener.volume= volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
