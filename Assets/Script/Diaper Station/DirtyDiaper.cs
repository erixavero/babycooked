using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDiaper : Consumable
{
    public override IEnumerator DragUntilDrop()
    {
        while (!Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
            yield return null;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider.gameObject.name == "Trash Bin")
        {
            BabyToBeCleaned.instance.dirtyDiaperDiscarded = true;
        }
        Destroy(gameObject);
    }
}
