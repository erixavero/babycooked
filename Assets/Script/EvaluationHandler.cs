using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EvaluationHandler : MonoBehaviour
{
    public static EvaluationHandler instance;
    [SerializeField] private GameObject evaluationUI;
    [SerializeField] private GameObject[] starsImage;
    [SerializeField] private TMP_Text successText;
    [SerializeField] private TMP_Text mostSuccessText;
    [SerializeField] private TMP_Text failText;
    [SerializeField] private TMP_Text mostFailText;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        evaluationUI.SetActive(false);
    }

    public bool CheckIfGameIsFinished()
    {
    if (PlayerInteraction.instance.isCarryingBaby) return false;
        GameObject[] babyCribs = GameObject.FindGameObjectsWithTag("BabyCrib");
        foreach (var crib in babyCribs)
        {
            BabyCrib babyCrib = crib.GetComponent<BabyCrib>();
            if (babyCrib.currentBaby != null) return false;
        }
        if (DoorHandler.instance.currentGeneratedBaby < DataManager.instance.GetCurrentDifficulty().totalGeneratedBaby) return false;
        return true;
    }

    public void CalculateScore()
    {
        int babyNeedCount = DataManager.instance.GetCurrentDifficulty().babyNeedCount;
        float score = DataManager.instance.GetTotalSuccess() / babyNeedCount;
        int stars = 0;
        switch (score)
        {
            case float n when (n >= 0.9f):
                stars = 3;
                break;
            case float n when (n >= 0.70f):
                stars = 2;
                break;
            case float n when (n >= 0.50f):
                stars = 1;
                break;
            case float n when (n < 0.50f):
                stars = 0;
                break;
        }
        PlayerPrefs.SetInt("Level" + DataManager.instance.GetCurrentDifficulty().level +"Score", stars);
        evaluationUI.SetActive(true);
        for (int i = 0; i < stars; i++)
        {
            starsImage[i].SetActive(true);
        }

        successText.text = "Success : " + DataManager.instance.GetTotalSuccess().ToString();
        mostSuccessText.text = "Most Success Task : " + DataManager.instance.GetMostSuccessTask();
        failText.text = "Fail : " + DataManager.instance.GetTotalFail().ToString();
        mostFailText.text = "Most Fail Task : " + DataManager.instance.GetMostFailTask();
    }

    
}
