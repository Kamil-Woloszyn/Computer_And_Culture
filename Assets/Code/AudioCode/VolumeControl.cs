using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.value = audioSource.volume; // sync slider to current volume
    }

    void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }
}
