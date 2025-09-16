using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BabyPowder : DraggableItem 
{
    private Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    public override void OnMouseUp()
    {
        coll.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.name == "Baby To Be Cleaned")
        {
            Debug.Log("Hit Baby To Be Cleaned");
            BabyToBeCleaned.instance.babyPowderApplied = true;
        }
        coll.enabled = true;
        base.OnMouseUp();
    }
}
