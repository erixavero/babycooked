using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    public static Kettle instance;
    [SerializeField] private Animator kettleAnimator;

    [Header("Kettle UI")]
    [SerializeField] private Button heatingButton;
    [SerializeField] private Image heatingIndicator;
    [SerializeField] private Color heatingColor;
    [SerializeField] private Color stopHeatingColor;
    [SerializeField] private Color overHeatColor;

    [Header("Kettle Settings")]
    public bool isPouring;
    public int heatingLevel;
    public float heatingDuration;
    private bool isHeating;
    void Awake()
    {
        instance = this;
        kettleAnimator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        heatingLevel = 0;
        heatingDuration = heatingDuration > 0 ? heatingDuration : 5f;
        heatingIndicator.fillAmount = 0f;
    }

    void OnMouseDown()
    {
        if (isHeating || isPouring) return;
        if (heatingLevel > 0f)
        {
            kettleAnimator.SetTrigger("Pouring");
            isPouring = true;
        }
    }

    public void FinishedPouring()
    {
        kettleAnimator.SetTrigger("FinishPouring");
        heatingLevel = 0;
        heatingIndicator.fillAmount = 0f;
        isPouring = false;
        MilkBottle.instance.waterIndicator.fillAmount = 1f;
        MilkBottle.instance.ingredients.Add("Hot Water");
    }

    public void HeatingButton()
    {
        if (isPouring) return;
        if (isHeating && heatingLevel != 0)
        {
            isHeating = false;
            StopAllCoroutines();
        }
        else if (!isHeating && heatingLevel == 0)
        {
            StartCoroutine(HeatKettle());
        }
    }

    IEnumerator HeatKettle()
    {
        float elapsedTime = 0f;
        heatingIndicator.color = heatingColor;
        isHeating = true;
        while (true)
        {
            heatingIndicator.fillAmount += 1f / heatingDuration;
            if (heatingIndicator.fillAmount >= 1f && elapsedTime == heatingDuration)
            {
                heatingIndicator.color = stopHeatingColor;
                heatingLevel = 1;
            }
            else if (heatingIndicator.fillAmount >= 1f && elapsedTime > heatingDuration)
            {
                heatingIndicator.color = overHeatColor;
                heatingLevel = 2;
            }
            Debug.Log(heatingLevel);
            elapsedTime += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
