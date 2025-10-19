using UnityEngine;
using UnityEngine.UI;

public class LevelButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] starsFilled;
    [SerializeField] private int level;
    [SerializeField] private int currentLevelScore;
    private Button currentButton;
    [SerializeField] private GameObject lockedLevel;

    void Start()
    {
        currentButton = GetComponent<Button>();
        currentLevelScore = GetScore();
        LockLevel();
        SetStars();
    }
    int GetScore()
    {
        return PlayerPrefs.GetInt("Level" + level + "Score", 0);
    }

    void SetStars()
    {
        for (int i = 0; i < starsFilled.Length; i++)
        {
            if (i < currentLevelScore) starsFilled[i].SetActive(true);
            else starsFilled[i].SetActive(false);
        }
    }

    void LockLevel()
    {
        if (level > 1)
        {
            currentButton.interactable = false;
            lockedLevel.SetActive(true);
            int previousLevelScore = PlayerPrefs.GetInt("Level" + (level - 1) + "Score", 0);
            if (previousLevelScore > 0)
            {
                currentButton.interactable = true;
                lockedLevel.SetActive(false);
            }
        }
    }

}
