using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using MADD;

[Docs("This script is used to control the main menu.")]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] AudioMixer masterMixer;

    [Docs("This function is used to play the game.")]
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    [Docs("This function is used to quit the game.")]
    public void QuitGame()
    {
        Application.Quit();
    }

    [Docs("This function is used to play the audio.")]
    public void PlayAudio()
    {
        clickAudio.Play();
    }

    [Docs("This function is used to set the volume from saved value.")]
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    [Docs("This function is used to set the volume.")]
    public void SetVolume(float value)
    {
        if (value < 1)
        {
            value = .001f;
        }
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20f);
    }
}
