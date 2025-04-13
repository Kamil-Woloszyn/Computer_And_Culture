/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 24th March 2025
 * FUNCTION: Adding sounds to the button objects on clicking them
 */
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
        //Function targetting the audio source on the gameobject itself
        TargetAudioSource = GetComponent<AudioSource>();
        Debug.Log(TargetAudioSource == null ? "TargetAudioSource for button clicks Not Found" : "TargetAudioSource for button clicks Found");
        int i = 0;
        //Adding the listener to all of the buttons added to the script in the inspector
        foreach (Button button in allButtonsInScene)
        {
            button.onClick.AddListener(ButtonClickedSound);
            Debug.Log("Added Button: " + i++ + "  Instance ID: "+button.GetInstanceID());
        }
    }

    /// <summary>
    /// Function which plays a button click sound when a button is pressed
    /// </summary>
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
