using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;
    public List<AudioClip> musicPlaylist = null;
    private bool changedTrackRecently_Flag = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.value = audioSource.volume; // sync slider to current volume
        audioSource.clip = musicPlaylist[0];
    }

    private void Update()
    {
        //Change the track if there is nothing playing and the track was not changed in the last while
        if(!audioSource.isPlaying && !changedTrackRecently_Flag)
        {
            ChangeTrack(musicPlaylist[Random.Range(0, musicPlaylist.Count)]);
            changedTrackRecently_Flag = true;
            audioSource.Play();
        }
        if (changedTrackRecently_Flag)
        {
            timer += Time.deltaTime;
            if (timer > 20f)
            {
                changedTrackRecently_Flag = false;
                timer = 0;
            }
        }
    }

    /// <summary>
    /// Function to change the volume based on value passed in
    /// </summary>
    /// <param name="value"></param>
    void ChangeVolume(float value)
    {
        audioSource.volume = value / 4;
    }

    /// <summary>
    /// Function to change tracks manually
    /// </summary>
    /// <param name="clip"></param>
    void ChangeTrack(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
