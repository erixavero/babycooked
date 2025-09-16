using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableBox : MonoBehaviour
{
    [SerializeField] private GameObject spawnedObject;
    void OnMouseDown()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        GameObject spawnedObjectInstance = Instantiate(spawnedObject, mouseWorldPos, spawnedObject.transform.rotation, transform);
    }
}
