using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;
    private AudioSource backgroundMusic;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        backgroundMusic = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if (backgroundMusic.isPlaying) return;
        backgroundMusic.Play();
    }

    public void StopMusic()
    {
        if (!backgroundMusic.isPlaying) return;
        backgroundMusic.Stop();
    }
    private void Start()
    {
    }
}
