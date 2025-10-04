using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    public string audioName;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public bool loop;
    public Sound()
    {
        volume = 1f;
        loop = false;
    }

}

public class AudioManager : MonoBehaviour
{
    public Sound[] musics;
    public Sound[] sfxs;
    public static AudioManager instance;
    public AudioSource musicSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic("MainMenu");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        musicSource.clip = s.clip;
        musicSource.volume = s.volume;
        musicSource.loop = s.loop;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxs, sound => sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioSource.PlayClipAtPoint(s.clip, Camera.main.transform.position, s.volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        foreach (var s in sfxs)
        {
            s.volume = volume;
        }
    }
}
