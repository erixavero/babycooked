using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private Baby babyData;
    protected virtual void OnEnable()
    {
        
    }

    public void CloseStation()
    {
        gameObject.SetActive(false);
    }

    public void OpenStation()
    {
        gameObject.SetActive(true);
    }

    protected virtual void OnDisable()
    {
        PlayerInteraction.instance.StopInteraction();
    }

    public void GetBabyData()
    {
        babyData = PlayerInteraction.instance.babyBeingHeld;
    }
}
