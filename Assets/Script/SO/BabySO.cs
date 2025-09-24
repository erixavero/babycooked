using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Baby", menuName = "Baby")]

[System.Serializable]
public class BabySprite
{
    public string name;
    public Sprite[] sprite;
}
public class BabySO : ScriptableObject
{
    public string babyName;
    public float milkNeeded;
    public BabySprite[] babySprites;
}
