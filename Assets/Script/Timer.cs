using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public Image timerImage;
    public float totalTime;
    public UnityEvent onTimesUp;

    void OnEnable()
    {
        totalTime = PlayerInteraction.instance.babyBeingHeld.fulfillTime;
    }

    void Start()
    {
        timerImage.fillAmount = 1f;
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            timerImage.fillAmount = 1f - (elapsedTime / totalTime);
            yield return null;
        }
        onTimesUp.Invoke();
    }
}
