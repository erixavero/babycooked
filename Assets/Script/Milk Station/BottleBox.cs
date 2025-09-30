using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBox : MonoBehaviour
{
    [SerializeField] private GameObject milkBottle;

    void Start()
    {
        milkBottle.SetActive(false);
    }

    void OnMouseDown()
    {
        if(milkBottle.activeSelf) return;
        milkBottle.SetActive(true);
    }
}
