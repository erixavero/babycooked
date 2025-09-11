using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPowder : MonoBehaviour
{
    [SerializeField] private float powderAmount;
    public 

    void AddPowder(GameObject targetObject)
    {
        MilkBottle targetbottle = targetObject.GetComponent<MilkBottle>();
    }

    void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider.gameObject.name == "Milk Bottle")
        {
            AddPowder(hit.collider.gameObject);
        }
    }
}
