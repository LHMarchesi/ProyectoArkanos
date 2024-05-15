using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public AudioSource musicSource;
    public AudioSource SFXSource;

    private void Start()
    {
       
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {

        SFXSource.PlayOneShot(clip);    
    }

    
}
