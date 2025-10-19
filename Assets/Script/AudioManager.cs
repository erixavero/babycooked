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

    public void PlaySFX(string clipName)
    {
        if (CheckSFXPlaying(clipName))
        {
            Debug.Log("Audio " + clipName + " already playing");
            return;
        }
        Sound sfx = Array.Find(sfxs, sound => sound.audioName == clipName);
        if (sfx != null)
        {
            AudioSource tempSource = gameObject.AddComponent<AudioSource>();
            tempSource.name = sfx.audioName;
            tempSource.clip = sfx.clip;
            tempSource.volume = sfx.volume;
            tempSource.Play();
            if(!sfx.loop)
            {
                Destroy(tempSource, sfx.clip.length);
            }
        }
        else
        {
            Debug.Log("Could not find SFX clip: " + clipName);
        }
    }

    public bool CheckSFXPlaying(string clipName)
    {
        AudioSource[] sfx = GetComponents<AudioSource>();
        foreach (var source in sfx)
        {
            if (source.name == clipName && source.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    public void StopSFX(string name)
    {
        AudioSource[] sfx = GetComponents<AudioSource>();
        foreach (var source in sfx)
        {
            if (source.name == name && source.isPlaying)
            {
                source.Stop();
                Destroy(source);
            }
        }
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
