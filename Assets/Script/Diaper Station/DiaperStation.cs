using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaperStation : MonoBehaviour
{
    public static DiaperStation instance;
    void Awake()
    {
        instance = this;
    }
    void OnEnable()
    {
        Debug.Log("on enable");
        Camera.main.transparencySortAxis = new Vector3(0, 0, 1);
    }

    void OnDisable()
    {
        Debug.Log("on disable");
        Camera.main.transparencySortAxis = new Vector3(0, 1, 0);
    }
}
