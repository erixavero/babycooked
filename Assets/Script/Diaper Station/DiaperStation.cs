using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaperStation : Station
{
    public static DiaperStation instance;
    void Awake()
    {
        instance = this;
    }
}
