using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderSpoon : Consumable
{
    [SerializeField] private Transform powderPosition;
    public float powderAmount;
    public float targetPowderAmount;

    public override IEnumerator DragUntilDrop()
    {
        while (!Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
            yield return null;
        }
        RaycastHit2D hit = Physics2D.Raycast(powderPosition.position, Vector2.zero);
        Debug.Log(hit.collider.gameObject.name);
        if (hit.collider.gameObject.name == "Milk Bottle")
        {
            Debug.Log("Hit Milk Bottle");
            hit.collider.gameObject.GetComponent<MilkBottle>().milkPowderAmount += powderAmount;
            if (hit.collider.gameObject.GetComponent<MilkBottle>().milkPowderAmount >= targetPowderAmount)
            {
                hit.collider.gameObject.GetComponent<MilkBottle>().ingredients.Add("Milk Powder");
            }
        }

        Destroy(gameObject);
    }
}
