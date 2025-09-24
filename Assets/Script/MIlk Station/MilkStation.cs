using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStation : Station
{
    public static MilkStation instance;

    void Awake()
    {
        instance = this;
    }
}
