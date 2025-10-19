using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private List<DifficultySO> allDifficulties;
    private DifficultySO currentDifficulty;
    public Dictionary<string, int> taskSuccessCount = new Dictionary<string, int>
    {
        {"Milk", 0},
        {"Diaper", 0},
        {"Bath", 0}
    };

    public Dictionary<string, int> taskFailCount = new Dictionary<string, int>
    {
        {"Milk", 0},
        {"Diaper", 0},
        {"Bath", 0}
    };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void initializeNewGame()
    {
        taskFailCount = new Dictionary<string, int>
        {
            {"Milk", 0},
            {"Diaper", 0},
            {"Bath", 0}
        };
        
        taskFailCount = new Dictionary<string, int>
        {
            {"Milk", 0},
            {"Diaper", 0},
            {"Bath", 0}
        };
    }

    public string GetMostSuccessTask()
    {
        string mostSuccessTask = "";
        int maxSuccess = -1;
        foreach (var task in taskSuccessCount)
        {
            if (task.Value > maxSuccess)
            {
                maxSuccess = task.Value;
                mostSuccessTask = task.Key;
            }
        }
        if (maxSuccess == 0) mostSuccessTask = "None";
        return mostSuccessTask;
    }

    public string GetMostFailTask()
    {
        string mostFailTask = "";
        int maxFail = -1;
        foreach (var task in taskFailCount)
        {
            if (task.Value > maxFail)
            {
                maxFail = task.Value;
                mostFailTask = task.Key;
            }
        }
        if (maxFail == 0) mostFailTask = "None";
        return mostFailTask;
    }

    public int GetTotalSuccess()
    {
        int total = 0;
        foreach (var count in taskSuccessCount.Values)
        {
            total += count;
        }
        return total;
    }

    public int GetTotalFail()
    {
        int total = 0;
        foreach (var count in taskFailCount.Values)
        {
            total += count;
        }
        return total;
    }

    public void AddSuccess(string task)
    {
        taskSuccessCount[task]++;
        AudioManager.instance.PlaySFX("Baby Laugh");
        Debug.Log($"Success Count for {task}: {taskSuccessCount[task]}");
    }

    public void AddFail(string task)
    {
        taskFailCount[task]++;
        AudioManager.instance.PlaySFX("Baby Cry");
        Debug.Log($"Fail Count for {task}: {taskFailCount[task]}");
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
        initializeNewGame();
        Debug.Log("Difficulty set to: " + currentDifficulty.level);
    }

    public DifficultySO GetCurrentDifficulty()
    {
        return currentDifficulty;
    }
}
