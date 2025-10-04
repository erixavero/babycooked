using System.Collections;
using System.Collections.Generic;
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
        minimumMixCount = PlayerInteraction.instance.babyBeingHeld.shakeNeeded;
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
            Debug.Log("Milk is ready!");
            StartCoroutine(CoolDown(1f));
            PlayerInteraction.instance.babyBeingHeld.currentNeed = Baby.BabyNeeds.None;
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
            StartCoroutine(CoolDown(0.05f));
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
