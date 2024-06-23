using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    private bool muted = false;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

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

    public void SetVolumeFromSlider()
    {
        if (!muted)
        {
            SetVolume(soundSlider.value);
        }
    }

    public void RefreshSlider(float value)
    {
        soundSlider.value = value;
    }

    public void MuteMusic()
    {
        muted = !muted;
        if(muted)
        {
            masterMixer.SetFloat("MasterVolume", -80.0f);
        }
        else
        {
            SetVolumeFromSlider();
        }
    }
}
