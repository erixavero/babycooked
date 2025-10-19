using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Animator tutorialAnimator;
    private int index;

    void Start()
    {
        index = 0;
        if (DataManager.instance.GetCurrentDifficulty().level == 1)
        {
            tutorialPanel.SetActive(true);
            tutorialAnimator.Play("Tutor_" + index);
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
        if (index < 17 && index >= 0)
        {
            index++;
            tutorialAnimator.Play("Tutor_" + index);
        }
    }

    public void PreviousTutorial()
    {
        if (index < 17 && index >= 0)
        {
            index--;
            tutorialAnimator.Play("Tutor_" + index);
        }
    }
}