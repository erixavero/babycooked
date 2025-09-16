using UnityEngine;

public abstract class DraggableItem : MonoBehaviour
{
    protected Vector3 originalPosition;
    protected Vector3 mouseOffset;

    public virtual void OnMouseDown()
    {
        Debug.Log("Dragging " + gameObject.name);
        originalPosition = transform.position;
        mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }
    public virtual void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos + mouseOffset;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }
    public virtual void OnMouseUp()
    {
        transform.position = originalPosition;
    }
}
