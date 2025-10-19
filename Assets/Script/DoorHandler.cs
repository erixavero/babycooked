using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public static DoorHandler instance;
    [SerializeField] private List<BabySO> allBabyDatas;
    public int currentGeneratedBaby;
    public Baby currentBaby;
    [Header("Generating Settings")]
    [SerializeField] private GameObject babyAvailableIndicator;
    [SerializeField] private int generatingDelay;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        babyAvailableIndicator.SetActive(false);
        currentGeneratedBaby = 0;
        currentBaby = null;
        StartCoroutine(BabyGenerator());
    }
    void GenerateBaby()
    {
        if (allBabyDatas.Count == 0) return;
        if (currentBaby != null) return;
        BabySO selectedBaby = allBabyDatas[Random.Range(0, allBabyDatas.Count)];
        DifficultySO difficultySelected = DataManager.instance.GetCurrentDifficulty();
        currentBaby = new Baby(selectedBaby, difficultySelected);
        currentGeneratedBaby++;
        babyAvailableIndicator.SetActive(true);
    }

    IEnumerator BabyGenerator()
    {
        while (DataManager.instance == null)
        {
            yield return null;
        }
        while (currentGeneratedBaby < DataManager.instance.GetCurrentDifficulty().totalGeneratedBaby)
        {
            GenerateBaby();
            yield return new WaitForSeconds(generatingDelay);
        }
    }

    public Baby GiveBaby()
    {
        Baby temp = currentBaby;
        currentBaby = null;
        babyAvailableIndicator.SetActive(false);
        return temp;
    }
}
