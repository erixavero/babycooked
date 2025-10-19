using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathingStation : Station
{
    public static BathingStation instance;
    public GameObject temperatureGameObject;
    public GameObject scrubbingGameObject;

    void Awake()
    {
        instance = this;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        OpenTempGame();
        AudioManager.instance.PlaySFX("Shower");
    }

    public void OpenScrubGame()
    {
        temperatureGameObject.SetActive(false);
        scrubbingGameObject.SetActive(true);
    }

    public void OpenTempGame()
    {
        temperatureGameObject.SetActive(true);
        scrubbingGameObject.SetActive(false);
    }
}
