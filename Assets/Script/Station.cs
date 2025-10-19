using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private Baby babyData;
    [SerializeField] private GameObject interactUI;

    void Start()
    {
        interactUI.SetActive(false);
    }
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
        if (PlayerInteraction.instance.isCarryingBaby)
        {
            babyData = PlayerInteraction.instance.babyBeingHeld;
        }
        else
        {
            babyData = null;
        }
    }

    public void ShowUI()
    {
        interactUI.SetActive(true);
    }
    
    public void HideUI()
    {
        interactUI.SetActive(false);
    }
}
