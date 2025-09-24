using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private int successCount;
    private int failCount;

    void Awake()
    {
        instance = this;
    }

    public void AddSuccess()
    {
        successCount++;
        Debug.Log("Success Count: " + successCount);
    }

    public void AddFail()
    {
        failCount++;
        Debug.Log("Fail Count: " + failCount);
    }


}
