using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Baby
{
    public enum BabyNeeds
    {
        None,
        Milk,
        Diaper,
        Bath
    }

    public BabySO babyData;
    public BabyNeeds currentNeed;
    public float intervalBetweenNeeds;
    public float timeToFulfillNeed;

    public Baby(BabySO data, float interval, float fulfillTime)
    {
        babyData = data;
        currentNeed = BabyNeeds.None;
        intervalBetweenNeeds = interval;
        timeToFulfillNeed = fulfillTime;
    }
}
public class BabyCrib : MonoBehaviour
{
    [SerializeField] private List<BabySO> allBabyDatas;
    public Baby currentBaby;

    [Header("BabyCrib UI")]
    [SerializeField] private GameObject babyInCrib;

    void Start()
    {
        babyInCrib.SetActive(false);
        GenerateBaby();
    }

    void GenerateBaby()
    {
        if (allBabyDatas.Count == 0) return;

        BabySO selectedData = allBabyDatas[Random.Range(0, allBabyDatas.Count)];
        currentBaby = new Baby(selectedData, 5f, 2f);
        babyInCrib.SetActive(true);
    }

    public Baby GiveBaby()
    {
        Baby temp = currentBaby;
        currentBaby = null;
        babyInCrib.SetActive(false);
        return temp;
    }

    public void AcceptBaby(Baby baby)
    {
        if( currentBaby != null) return;
        currentBaby = baby;
        babyInCrib.SetActive(true);
    }


}
