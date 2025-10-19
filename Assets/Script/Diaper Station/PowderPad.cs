using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderPad : Consumable
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
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "Baby To Be Cleaned")
            {
                if (!BabyToBeCleaned.instance.dirtyDiaperDiscarded || !BabyToBeCleaned.instance.isBabyWiped) yield return null;
                BabyToBeCleaned.instance.babyPowderApplied = true;
                // BabyToBeCleaned.instance.SetBabySprite("NakedWithDiaper");
            }
        }
        Destroy(gameObject);
    }
}
