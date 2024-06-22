using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using MADD;

[Docs("Displays the pause menu and allows the player to resume the game, go to the main menu, and adjust the volume.")]
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] AudioMixer masterMixer;
    public static bool isPaused;

    [Docs("Gets saved volume from PlayerPrefs and sets the volume to the saved volume.")]
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    [Docs("Checks if the player presses the escape key and pauses or resumes the game.")]
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    [Docs("Pauses the game and sets the time scale to 0.")]
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    [Docs("Resumes the game and sets the time scale to 1.")]
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    [Docs("Goes to the main menu and sets the time scale to 1.")]
    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    [Docs("Sets the volume to the value and saves the volume to PlayerPrefs.")]
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
