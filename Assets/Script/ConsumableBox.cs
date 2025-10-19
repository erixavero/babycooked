using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableBox : MonoBehaviour
{
    [SerializeField] private GameObject spawnedObject;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightedSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
    }

    void OnMouseEnter()
    {
        spriteRenderer.sprite = highlightedSprite;
        spriteRenderer.sortingOrder++;
    }

    void OnMouseExit()
    {
        spriteRenderer.sprite = normalSprite;
        spriteRenderer.sortingOrder--;
    }

    void OnMouseDown()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        GameObject spawnedObjectInstance = Instantiate(spawnedObject, mouseWorldPos, spawnedObject.transform.rotation, transform);
    }
}
