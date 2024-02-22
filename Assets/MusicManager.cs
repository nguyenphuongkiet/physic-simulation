using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    private void Start()
    {
        Play(audioClip, true);
    }
    public void Play(AudioClip musicToPlay, bool interupt = false)
    {
        if (musicToPlay == null) { return; }
        if (interupt == true)
        {
            audioSource.volume = 1f;
            audioSource.clip = musicToPlay;
            audioSource.Play();
        }
    }
}
