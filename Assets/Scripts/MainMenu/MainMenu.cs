using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] AudioMixer masterMixer;

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAudio()
    {
        clickAudio.Play();
    }

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

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
