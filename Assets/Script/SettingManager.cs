using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;
    [SerializeField] private GameObject settings;
    public Slider musicSlider;
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
        settings.SetActive(false);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = musicSlider.value;
    }

    void Update()
    {
        SetMusicVolume();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        settings.SetActive(!settings.activeSelf);
        if(settings.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void SetMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
