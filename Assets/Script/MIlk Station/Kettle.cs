using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    [Header("Kettle UI")]
    [SerializeField] private Button heatingButton;
     
    [Header("Kettle Settings")]
    [SerializeField] private Image heatingIndicator;
    public string kettleCondition;
    public float heatingDuration;
    void OnEnable()
    {
        kettleCondition = "Cold";
        heatingDuration = heatingDuration > 0 ? heatingDuration : 5f;
        heatingIndicator.fillAmount = 0f;
    }

    public void StartHeating()
    {
        StartCoroutine(HeatKettle());
    }

    IEnumerator HeatKettle()
    {
        while (heatingIndicator.fillAmount < 1f)
        {
            heatingIndicator.fillAmount += 1f / heatingDuration * Time.deltaTime;
            yield return new WaitForSeconds(1f / heatingDuration * Time.deltaTime);
        }
        kettleCondition = "Hot";
    }
}
