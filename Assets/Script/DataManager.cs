using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private List<DifficultySO> allDifficulties;
    private DifficultySO currentDifficulty;
    private int successCount;
    private int failCount;
    public Dictionary<string, int> taskSuccessCount = new Dictionary<string, int>
    {
        {"Milk", 0},
        {"Diaper", 0},
        {"Bath", 0}
    };

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetDifficulty(1);
    }

    public void AddSuccess(string task)
    {
        taskSuccessCount[task]++;
        Debug.Log($"Success Count for {task}: {taskSuccessCount[task]}");
    }

    public void AddFail()
    {
        failCount++;
        Debug.Log("Fail Count: " + failCount);
    }

    public void SetDifficulty(int level)
    {
        level--;
        if (level < 0 || level >= allDifficulties.Count)
        {
            Debug.LogError("Invalid difficulty level");
            return;
        }
        currentDifficulty = allDifficulties[level];
        Debug.Log("Difficulty set to: " + currentDifficulty.level);
    }

    public DifficultySO GetCurrentDifficulty()
    {
        return currentDifficulty;
    }
}
