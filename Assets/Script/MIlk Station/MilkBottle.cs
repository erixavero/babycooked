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
            StartCoroutine(CoolDown());
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

    IEnumerator CoolDown() 
    {
        isCoolDown = true;
        yield return new WaitForSeconds(0.05f);
        isCoolDown = false;
    }

    void TransitionMilkColor() 
    {
        currentColor = waterIndicator.color;
        waterIndicator.color = Color.Lerp(currentColor, targetColor, (float)mixCounter / minimumMixCount);
    }
}
