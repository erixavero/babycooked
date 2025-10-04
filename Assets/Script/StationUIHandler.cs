using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationUIHandler : MonoBehaviour
{
    public GameObject interactUI;
    // Start is called before the first frame update
    void Start()
    {
        interactUI.SetActive(false);
    }

    // Update is called once per frame
    public void ShowUI()
    {
        interactUI.SetActive(true);
    }

    public void HideUI()
    {
        interactUI.SetActive(false);
    }
}
