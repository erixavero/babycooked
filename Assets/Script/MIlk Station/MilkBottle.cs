using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MilkBottle : DraggableItem
{
    [Header("Utilities")]
    public static MilkBottle instance;
    private Collider2D coll;

    [Header("Bottle UI")]
    [SerializeField] private Color startingColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private Color currentColor;
    public Image waterIndicator;
    public Image milkPowderIndicator;
    public Sprite[] milkPowderSprites;

    [Header("Bottle Settings")]
    public float milkPowderAmount;
    [SerializeField] private int mixCounter;
    [SerializeField] private float minimumMixCount;
    private bool isCoolDown;
    private bool aboveZero;
    private bool belowZero;
    public List<string> ingredients;

    void Awake()
    {
        instance = this;
        coll = GetComponent<Collider2D>();
    }
    void OnEnable()
    {
        mixCounter = 0;
        milkPowderAmount = 0f;
        UpdateMilkPowderUI();
        if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
        {
            minimumMixCount = PlayerInteraction.instance.babyBeingHeld.shakeNeeded;
        }
        else
        {
            minimumMixCount = 1f;
        }
        aboveZero = false;
        belowZero = false;
        isCoolDown = false;
        ingredients = new List<string>();
        waterIndicator.color = startingColor;
        waterIndicator.fillAmount = 0f;
    }

    public override void OnMouseDrag()
    {
        if (Kettle.instance.isPouring) return;
        if (!checkIngredient()) return;

        base.OnMouseDrag();

        if (!isCoolDown && checkIngredient()) 
        {
            Shake(Input.GetAxis("Mouse Y")); 
        }
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
        if (mixCounter >= minimumMixCount)
        {
            // Debug.Log("Milk is ready!");
            StartCoroutine(CoolDown(1f));
            if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
                PlayerInteraction.instance.babyBeingHeld.currentNeed = Baby.BabyNeeds.None;
            DataManager.instance.AddSuccess("Milk");
            MilkStation.instance.CloseStation();
        }

    }

    private void Shake(float input)
    {
        if (input == 0)
        {
            return;
        }
        if (input > 0.5f)
        {
            aboveZero = true;
        }
        if (input < -0.5f)
        {
            belowZero = true;
        }
        if (aboveZero && belowZero)
        {
            mixCounter++;
            aboveZero = false;
            belowZero = false;
            TransitionMilkColor();
            AudioManager.instance.PlaySFX("Bottle Shake");
            StartCoroutine(CoolDown(0.05f));
        }
    }

    public void UpdateMilkPowderUI()
    {
        if (milkPowderAmount <= 0)
        {
            milkPowderIndicator.gameObject.SetActive(false);
        }
        else
        {
            milkPowderIndicator.gameObject.SetActive(true);
            milkPowderIndicator.sprite = milkPowderSprites[(int)milkPowderAmount / 50];
        }
    }

    bool checkIngredient()
    {
        if (ingredients.Contains("Milk Powder") && ingredients.Contains("Hot Water")) 
        {
            return true;
        }
        return false;
    }

    IEnumerator CoolDown(float time) 
    {
        isCoolDown = true;
        yield return new WaitForSeconds(time);
        isCoolDown = false;
    }

    void TransitionMilkColor() 
    {
        currentColor = waterIndicator.color;
        waterIndicator.color = Color.Lerp(currentColor, targetColor, (float)mixCounter / minimumMixCount);
    }
}
