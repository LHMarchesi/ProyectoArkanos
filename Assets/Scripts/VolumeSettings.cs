using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        SetVolumeMusic();
        SetVolumeSFX();
    }
    public void SetVolumeMusic()
    {
        float volume = musicSlider.value;
        MusicSource.volume = volume;
    }


    public void SetVolumeSFX()
    {
        float volume = sfxSlider.value;
        SFXSource.volume = volume;
    }
}

