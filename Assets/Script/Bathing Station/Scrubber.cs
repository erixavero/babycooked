using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scrubber : DraggableItem
{
    private Collider2D scrubberCollider;
    private Vector3 defaultPos;
    [SerializeField] private ParticleSystem bubbleEffect;

    void Awake()
    {
        bubbleEffect.Stop();
        scrubberCollider = GetComponent<Collider2D>();
        defaultPos = transform.position;
    }

    void OnEnable()
    {
        transform.position = defaultPos;
    }
    
    public override void OnMouseDrag()
    {
        scrubberCollider.enabled = false;
        base.OnMouseDrag();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            // Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "BabyInBath")
            {
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    bubbleEffect.Emit(1);
                    ScrubMinigame.instance.AddHygiene(0.1f);
                }
            }
        }
    }

    public override void OnMouseUp()
    {
        scrubberCollider.enabled = true;
        bubbleEffect.Stop();
        base.OnMouseUp();
    }
}
