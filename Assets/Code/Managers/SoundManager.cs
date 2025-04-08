using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip UI_Click_Sound = null;

    private AudioSource TargetAudioSource = null;

    private static SoundManager instance = null;
    [SerializeField] 
    private List<Button> allButtonsInScene;

    public static SoundManager instanceClass
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        TargetAudioSource = GetComponent<AudioSource>();
        int i = 0;
        foreach (Button button in allButtonsInScene)
        {
            button.onClick.AddListener(ButtonClickedSound);
            Debug.Log("Added Button: " + i++ + "  Instance ID: "+button.GetInstanceID());
        }
    }

    public void ButtonClickedSound()
    {
        TargetAudioSource.pitch = Random.Range(0.9f, 1.1f);
        if (TargetAudioSource.clip == null)
        {
            TargetAudioSource.clip = UI_Click_Sound;
        }
        TargetAudioSource.Play();
    }

}
