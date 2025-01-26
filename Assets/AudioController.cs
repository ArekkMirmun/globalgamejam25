using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    public static AudioController instance;
    
    [SerializeField] private AudioSource buttonClick;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource collectableSound;
    [SerializeField] private AudioSource bubblePop;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }
    
    public void PlayButtonClick()
    {
        buttonClick.Play();
    }
    
    public void PlayCollectableSound()
    {
        collectableSound.Play();
    }
    
    public void PlayBubblePop()
    {
        bubblePop.Play();
    }
    
}
