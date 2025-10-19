using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonHandler : MonoBehaviour
{
    public Button pauseButton;

    void Start()
    {
        if (SettingManager.instance != null)
        {
            pauseButton.onClick.AddListener(() =>
            {
                SettingManager.instance.ToggleSettings();
            });
        }
    }
}
