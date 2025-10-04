using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrubMinigame : MonoBehaviour
{
    [Header("Object References")]
    public static ScrubMinigame instance;
    [SerializeField] private Slider hygieneMeter;
    [SerializeField] private GameObject scrubber;

    [Header("Utilities")]
    public bool shampooGiven;
    public bool soapGiven;

    void Awake()
    {
        instance = this;
        shampooGiven = false;
        soapGiven = false;
        scrubber.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (shampooGiven)
        {
            scrubber.GetComponent<Collider2D>().enabled = true;
        }
    }

    public void AddHygiene(float amount)
    {
        if (hygieneMeter.value >= hygieneMeter.maxValue / 2 && !soapGiven) return;
        if (hygieneMeter.value >= hygieneMeter.maxValue)
        {
            CheckGameFinish();
            return;
        }
        hygieneMeter.value += amount;
    }

    public void CheckGameFinish()
    {
        if (hygieneMeter.value >= hygieneMeter.maxValue)
        {
            DataManager.instance.AddSuccess("Bath");
        }
        else
        {
            DataManager.instance.AddFail();
        }
        BathingStation.instance.CloseStation();
    }
}
