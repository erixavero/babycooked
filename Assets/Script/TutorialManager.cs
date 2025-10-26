using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Sprite[] allTutorialImages;
    public Image tutorialImage;
    private int index;

    void Start()
    {
        index = 0;
        tutorialImage.sprite = allTutorialImages[index];
        if (DataManager.instance.GetCurrentDifficulty().level == 1)
        {
            tutorialPanel.SetActive(true);
            
        }
        else
        {
            tutorialPanel.SetActive(false);
            Debug.Log("No Tutorial this level");
        }
    }

    public void OpenTutorialPanel()
    {
        tutorialPanel.SetActive(true);
        PlayerMovement.instance.canMove = false;
        Time.timeScale = 0f;
    }

    public void CloseTutorialPanel()
    {
        tutorialPanel.SetActive(false);
        PlayerMovement.instance.canMove = true;
        Time.timeScale = 1f;
    }

    public void NextTutorial()
    {
        index++;
        if(index >= allTutorialImages.Length) index = 0;
        tutorialImage.sprite = allTutorialImages[index];
    }

    public void PreviousTutorial()
    {
        index--;
        if(index < 0) index = allTutorialImages.Length - 1;
        tutorialImage.sprite = allTutorialImages[index];
    }
}