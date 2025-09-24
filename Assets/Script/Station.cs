using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Debug.Log("on enable");
        Camera.main.transparencySortAxis = new Vector3(0, 0, 1); // Example: Y axis
    }

    public void CloseStation()
    {
        gameObject.SetActive(false);
    }

    public void OpenStation()
    {
        gameObject.SetActive(true);
    }

    void OnDisable()
    {
        Debug.Log("on disable");
        Camera.main.transparencySortAxis = new Vector3(0, 1, 0); // Reset to default
        PlayerInteraction.instance.StopInteraction();
    }
}
