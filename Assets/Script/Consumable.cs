using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DragUntilDrop());
    }
    public virtual IEnumerator DragUntilDrop()
    {
        while (!Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
