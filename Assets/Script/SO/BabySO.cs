using UnityEngine;
[System.Serializable]
public class BabySprite
{
    public string name;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "New Baby", menuName = "Baby")]
public class BabySO : ScriptableObject
{
    public string babyName;
    public float milkNeeded;
    public BabySprite[] babySprites;

    public BabySprite GetBabySpriteByName(string searchName)
    {
        foreach (var babySprite in babySprites)
        {
            if (babySprite.name == searchName)
                return babySprite;
        }
        return null; // Not found
    }
}
