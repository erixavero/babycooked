using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : DraggableItem
{
    private Collider2D soapCollider;

    void Awake()
    {
        soapCollider = GetComponent<Collider2D>();
    }
    public override void OnMouseUp()
    {
        soapCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "BabyInBath")
            {
                ScrubMinigame.instance.soapGiven = true;
            }
        }
        base.OnMouseUp();
        soapCollider.enabled = true;
    }
}
