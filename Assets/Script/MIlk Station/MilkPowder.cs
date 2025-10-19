using UnityEngine;

public class MilkPowder : MonoBehaviour
{
    [SerializeField] private GameObject powderSpoonPrefab;
    [SerializeField] private GameObject parentForSpoon;
    [SerializeField] private float powderAmount;
    [SerializeField] private float targetPowderAmount;
    void OnMouseDown()
    {
        if (PlayerInteraction.instance.isCarryingBaby && PlayerInteraction.instance.babyBeingHeld != null)
        {
            targetPowderAmount = PlayerInteraction.instance.babyBeingHeld.powderNeeded;
        }
        else
        {
            targetPowderAmount = 0f;
        }
        if (Kettle.instance.isPouring) return;
        if (MilkBottle.instance == null) return;
        if (MilkBottle.instance.milkPowderAmount >= targetPowderAmount) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        GameObject spoon = Instantiate(powderSpoonPrefab, mouseWorldPos, powderSpoonPrefab.transform.rotation, parentForSpoon.transform);
        spoon.GetComponent<PowderSpoon>().powderAmount = powderAmount;
        spoon.GetComponent<PowderSpoon>().targetPowderAmount = targetPowderAmount;
    }
}
