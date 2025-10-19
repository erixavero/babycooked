using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject backtomenuButton;
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

        restartButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            ToggleSettings();
            MenuHandler mh = FindObjectOfType<MenuHandler>();
            mh.RestartLevel();
        });

        backtomenuButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            ToggleSettings();
            MenuHandler mh = FindObjectOfType<MenuHandler>();
            mh.LoadScene("MainMenu");
        });
    }

    void Update()
    {
        SetMusicVolume();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            closeButton.SetActive(true);
            restartButton.SetActive(false);
            backtomenuButton.SetActive(false);
        }
        else
        {
            closeButton.SetActive(false);
            restartButton.SetActive(true);
            backtomenuButton.SetActive(true);
        }
    }

    public void ToggleSettings()
    {
        settings.SetActive(!settings.activeSelf);
        if (settings.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void SetMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    
    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
    }
}
