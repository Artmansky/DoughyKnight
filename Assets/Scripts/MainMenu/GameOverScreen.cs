using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

[Docs("This script is responsible for the game over screen.")]
public class GameOverScreen : MonoBehaviour
{
    private AudioSource backgroundMusic;

    [Docs("Plays music when the game over screen is enabled.")]
    public void Setup()
    {
        backgroundMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        backgroundMusic.Stop();
        gameObject.SetActive(true);
    }
}
