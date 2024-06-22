using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using MADD;

[Docs("Settings for the sound in the game.")]
public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;

    [Docs("Sets the volume of the game.")]
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    [Docs("Sets the volume of the game.")]
    public void SetVolume(float value)
    {
        if(value < 1)
        {
            value = .001f;
        }
        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value/100) * 20f);
    }

    [Docs("Sets the volume of the game from the slider.")]
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    [Docs("Refreshes the slider.")]
    public void RefreshSlider(float value)
    {
        soundSlider.value = value;
    }
}
