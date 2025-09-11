using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 mouseOffset;
    private Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        Debug.Log("Started dragging: " + gameObject.name);
        originalPosition = transform.position;
        mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        
    }

    private void OnMouseDrag()
    {
        // Debug.Log(Input.GetAxis("Mouse X")); 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos + mouseOffset;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }

    void OnMouseUp()
    {
        Debug.Log("Item released: " + gameObject.name);
        coll.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Dropping on: " + hit.collider.gameObject.name);
        }
        transform.position = originalPosition;
        coll.enabled = true;
    }
}
