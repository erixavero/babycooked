using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Baby
{
    public enum BabyNeeds
    {
        None,
        Milk,
        Diaper,
        Bath,
        GoHome
    }

    public BabySO babyData;
    public BabyNeeds currentNeed;
    [Header("Baby Attributes")]
    public float fulfillTime;
    public float patience;
    public float intervalBetweenNeeds;
    public int totalNeedCount;
    public int currentNeedCount;
    [Header("Milk Station Needs")]
    public int shakeNeeded;
    public int powderNeeded;

    public Baby(BabySO data, DifficultySO difficulty)
    {
        babyData = data;
        currentNeed = BabyNeeds.None;
        intervalBetweenNeeds = difficulty.babyIntervalBetweenNeeds;
        fulfillTime = difficulty.babyFulfillTime;
        shakeNeeded = difficulty.milkShakeNeeded;
        powderNeeded = difficulty.milkPowderNeeded;
        patience = difficulty.babyPatience;
        totalNeedCount = difficulty.babyNeedCount;
        currentNeedCount = 0;
    }
}
public class BabyCrib : MonoBehaviour
{
    [SerializeField] private List<BabySO> allBabyDatas;
    public Baby currentBaby;

    [Header("BabyCrib UI")]
    [SerializeField] private GameObject babyInCrib;
    [SerializeField] private GameObject babyNeedsUI;
    [SerializeField] private GameObject patienceMeterUI;
    [SerializeField] private Sprite[] babyNeedsSprites;

    void Start()
    {
        babyInCrib.SetActive(false);
        babyNeedsUI.SetActive(false);
        patienceMeterUI.SetActive(false);
        currentBaby = null;
    }

    public Baby GiveBaby()
    {
        Baby temp = currentBaby;
        currentBaby = null;
        babyInCrib.SetActive(false);
        babyNeedsUI.SetActive(false);
        patienceMeterUI.SetActive(false);
        StopAllCoroutines();
        return temp;
    }

    public void AcceptBaby(Baby baby)
    {
        // Debug.Log("current baby in crib" + currentBaby.babyData.babyName);
        if (currentBaby != null || baby.currentNeed != Baby.BabyNeeds.None)
        {
            Debug.Log("Crib is occupied or baby has needs");
            return;
        }
        currentBaby = null;
        currentBaby = baby;
        PlayerInteraction.instance.babyBeingHeld = null;
        PlayerInteraction.instance.isCarryingBaby = false;
        Debug.Log("Baby accepted: " + currentBaby.babyData.babyName);
        babyInCrib.SetActive(true);
        StartCoroutine(GenerateBabyNeeds());
    }

    IEnumerator GenerateBabyNeeds()
    {
        if (currentBaby == null) yield return null;
        if (currentBaby.currentNeed != Baby.BabyNeeds.None) yield return null;
        if (currentBaby.currentNeedCount > 0 && currentBaby.currentNeedCount < currentBaby.totalNeedCount)
        {
            Debug.Log("current baby need : " + currentBaby.currentNeedCount);
            yield return new WaitForSeconds(currentBaby.intervalBetweenNeeds);
        }
        else if (currentBaby.currentNeedCount >= currentBaby.totalNeedCount)
        {
            Debug.Log("Baby is going home");
            yield return new WaitForSeconds(currentBaby.intervalBetweenNeeds);
            currentBaby.currentNeed = Baby.BabyNeeds.GoHome;
            babyNeedsUI.SetActive(true);
            babyNeedsUI.GetComponent<SpriteRenderer>().sprite = babyNeedsSprites[4];
            yield break;
        }
        else
        {
            float rand = Random.Range(2f, 5f);
            yield return new WaitForSeconds(rand); // buffer time for first need
        }
        currentBaby.currentNeedCount++;
        int random = Random.Range(1, 4);
        currentBaby.currentNeed = (Baby.BabyNeeds)random;
        babyNeedsUI.SetActive(true);
        babyNeedsUI.GetComponent<SpriteRenderer>().sprite = babyNeedsSprites[random];
        StartCoroutine(DecreasePatience(1f));
    }

    IEnumerator DecreasePatience(float rate)
    {
        float currentPatience = currentBaby.patience;
        patienceMeterUI.SetActive(true);
        Image patienceMeterImage = patienceMeterUI.transform.GetChild(1).GetComponent<Image>();
        patienceMeterImage.fillAmount = currentPatience / currentBaby.patience;
        while (currentBaby != null && currentBaby.patience > 0)
        {
            yield return new WaitForSeconds(1f);
            currentPatience -= rate;
            patienceMeterImage.fillAmount = currentPatience / currentBaby.patience;

            if (currentPatience <= 0)
            {
                DataManager.instance.AddFail(currentBaby.currentNeed.ToString());
                Debug.Log("Baby is upset");
                currentBaby.currentNeed = Baby.BabyNeeds.GoHome;
                babyNeedsUI.GetComponent<SpriteRenderer>().sprite = babyNeedsSprites[4];
                // babyNeedsUI.SetActive(false);
                patienceMeterUI.SetActive(false);
                yield break;
            }
        }
    }
}
