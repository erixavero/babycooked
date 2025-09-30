using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyToBeCleaned : MonoBehaviour
{
    public static BabyToBeCleaned instance;
    [Header("Baby UI")]
    public Sprite cleanBabySprite;
    public Sprite dirtyBabySprite;
    public Sprite nakedBabySprite;
    [SerializeField] private SpriteRenderer babySpriteRenderer;
    [Header("Utilities")]
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
        babySpriteRenderer.sprite = PlayerInteraction.instance.babyBeingHeld.babyData.GetBabySpriteByName("WearingDirtyDiaper").sprite;
    }

    void Update()
    {
        if (dirtyDiaperDiscarded)
        {
            babySpriteRenderer.sprite = nakedBabySprite;
            if (babyPowderApplied)
            {
                babySpriteRenderer.sprite = cleanBabySprite;
            }
        }
    }

    void OnMouseDrag()
    {
        Debug.Log(Input.GetAxisRaw("Mouse X") + "," + Input.GetAxisRaw("Mouse Y"));
        if (dirtyDiaperDiscarded && cleanDiaperApplied && babyPowderApplied && isBabyWiped)
        {
            if (swipeUp)
            {
                switch (Input.GetAxisRaw("Mouse X"))
                {
                    case > 0.5f:
                        swipeRight = true;
                        break;
                    case < -0.5f:
                        swipeLeft = true;
                        break;
                }
            }

            switch (Input.GetAxisRaw("Mouse Y"))
            {
                case > 0.5f:
                    swipeUp = true;
                    break;
            }
        }
    }

    void OnMouseUp()
    {
        if (swipeLeft && swipeRight && swipeUp)
        {
            Debug.Log("Successfully Applied Baby Diaper");
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
        GameObject dirtyDiaperInstance = Instantiate(dirtyDiaper, mouseWorldPos, dirtyDiaper.transform.rotation, transform);
    }

    public void CheckFinish()
    {
        if (dirtyDiaperDiscarded && cleanDiaperApplied && babyPowderApplied && isBabyWiped)
        {
            DataManager.instance.AddSuccess();
        }
        else
        {
            DataManager.instance.AddFail();
        }
        DiaperStation.instance.CloseStation();
    }
}
