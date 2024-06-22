using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

public class GameOverScreen : MonoBehaviour
{
    private AudioSource backgroundMusic;
    public void Setup()
    {
        backgroundMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        backgroundMusic.Stop();
        gameObject.SetActive(true);
    }
}
