using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        babySpriteRenderer.sprite = dirtyBabySprite;
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
    void OnMouseDown()
    {
        if(dirtyDiaperDiscarded) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        GameObject dirtyDiaperInstance = Instantiate(dirtyDiaper, mouseWorldPos, dirtyDiaper.transform.rotation, transform);
    }
}
