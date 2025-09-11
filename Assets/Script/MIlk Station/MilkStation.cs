using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStation : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("on enable");
        Camera.main.transparencySortAxis = new Vector3(0, 0, 1); // Example: Y axis
    }

    void OnDisable()
    {
        Debug.Log("on disable");
        Camera.main.transparencySortAxis = new Vector3(0, 1, 0); // Reset to default
    }
}
