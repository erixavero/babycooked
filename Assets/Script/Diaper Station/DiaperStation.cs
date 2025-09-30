using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaperStation : Station
{
    public static DiaperStation instance;
    public Baby babyData;
    void Awake()
    {
        instance = this;
    }
}
