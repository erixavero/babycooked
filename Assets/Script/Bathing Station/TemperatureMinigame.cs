using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureMinigame : MonoBehaviour
{
    public Slider temperatureSlider;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float forceSpeed;
    [SerializeField] private float targetOffset;
    [SerializeField] private bool isPlaying;
    private float midpoint;

    void OnEnable()
    {
        midpoint = (temperatureSlider.maxValue + temperatureSlider.minValue) / 2;
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            float targetValue = temperatureSlider.value < midpoint ? temperatureSlider.minValue : temperatureSlider.maxValue;
            temperatureSlider.value = Mathf.MoveTowards(temperatureSlider.value, targetValue, forceSpeed * Time.deltaTime);
            float edgeDistance = Mathf.Abs((temperatureSlider.value - midpoint) / ((temperatureSlider.maxValue - temperatureSlider.minValue) / 2));
            float scaledPlayerSpeed = edgeDistance > 0.4f ? playerSpeed * edgeDistance : playerSpeed * 0.4f;
            if (Input.GetKeyDown(KeyCode.W))
            {
                temperatureSlider.value -= scaledPlayerSpeed;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                temperatureSlider.value += scaledPlayerSpeed;
            }
            temperatureSlider.value = Mathf.Clamp(temperatureSlider.value, temperatureSlider.minValue, temperatureSlider.maxValue);
        }
    }

    public void CheckLastValue()
    {
        isPlaying = false;
        if (Mathf.Abs(midpoint - temperatureSlider.value) <= targetOffset || Mathf.Abs(midpoint + temperatureSlider.value) <= targetOffset)
        {
            BathingStation.instance.OpenScrubGame();
        }
        else
        {
            DataManager.instance.AddFail("Bath");
            if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
                PlayerInteraction.instance.babyBeingHeld.currentNeed = Baby.BabyNeeds.None;
            BathingStation.instance.CloseStation();
        }
    }
}
