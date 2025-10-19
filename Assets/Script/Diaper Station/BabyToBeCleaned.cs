using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyToBeCleaned : MonoBehaviour
{
    public static BabyToBeCleaned instance;
    [SerializeField] private SpriteRenderer babySpriteRenderer;
    [Header("Utilities")]
    public GameObject dirtyDiaperInstance;
    public GameObject swipeIndicator;
    public bool dirtyDiaperDiscarded;
    public bool cleanDiaperApplied;
    public bool babyPowderApplied;
    public bool isBabyWiped;

    [Header("Apply Diaper Settings")]
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;

    [SerializeField] private GameObject dirtyDiaper;

    void Awake()
    {
        instance = this;
        babySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        dirtyDiaperDiscarded = false;
        cleanDiaperApplied = false;
        babyPowderApplied = false;
        isBabyWiped = false;
        swipeIndicator.SetActive(false);
        if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
        {
            babySpriteRenderer.sprite = PlayerInteraction.instance.babyBeingHeld.babyData.GetBabySpriteByName("WearingDirtyDiaper").sprite;
        }
        else
        {
            babySpriteRenderer.sprite = null;
        }
    }

    void OnMouseDrag()
    {
        if (dirtyDiaperDiscarded && cleanDiaperApplied && babyPowderApplied && isBabyWiped)
        {
            if (swipeUp)
            {
                if (swipeLeft)
                {
                    if(Input.GetAxisRaw("Mouse X") < -0.5f)
                    {
                        swipeRight = true;
                        swipeIndicator.SetActive(false);
                        SetBabySprite("WearingCleanDiaper");
                        AudioManager.instance.PlaySFX("Velcro");
                    }
                }
                else
                {
                    if(Input.GetAxisRaw("Mouse X") > 0.5f)
                    {
                        swipeLeft = true;
                        swipeIndicator.GetComponent<Animator>().Play("SwipeLeftAnim");
                        SetBabySprite("DiaperSwipeLeft");
                        AudioManager.instance.PlaySFX("Velcro");
                    }
                }
            }
            else
            {
                swipeIndicator.GetComponent<Animator>().Play("SwipeUpAnim");
                if (Input.GetAxisRaw("Mouse Y") > 0.5f)
                {
                    swipeUp = true;
                    swipeIndicator.GetComponent<Animator>().Play("SwipeRightAnim");
                    SetBabySprite("DiaperSwipeUp");
                    AudioManager.instance.PlaySFX("Velcro");
                }
            }
        }
    }

    void OnMouseUp()
    {
        if (swipeLeft && swipeRight && swipeUp)
        {
            // Debug.Log("Successfully Applied Baby Diaper");
            isBabyWiped = true;
            swipeLeft = false;
            swipeRight = false;
            swipeUp = false;
            CheckFinish();
        }
    }

    void OnMouseDown()
    {
        if (dirtyDiaperDiscarded) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        dirtyDiaperInstance = Instantiate(dirtyDiaper, mouseWorldPos, dirtyDiaper.transform.rotation, transform);
        SetBabySprite("Naked");
    }

    public void CheckFinish()
    {
        if (dirtyDiaperDiscarded && cleanDiaperApplied && babyPowderApplied && isBabyWiped)
        {
            DataManager.instance.AddSuccess("Diaper");
        }
        else
        {
            DataManager.instance.AddFail("Diaper");
        }
        if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
            PlayerInteraction.instance.babyBeingHeld.currentNeed = Baby.BabyNeeds.None;
        DiaperStation.instance.CloseStation();
    }

    public void SetBabySprite(string spriteName)
    {
        if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
            babySpriteRenderer.sprite = PlayerInteraction.instance.babyBeingHeld.babyData.GetBabySpriteByName(spriteName).sprite;
    }
}
