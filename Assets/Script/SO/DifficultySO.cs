using UnityEngine;

[CreateAssetMenu(fileName = "DifficultySO", menuName = "ScriptableObjects/DifficultySO", order = 1)]
public class DifficultySO : ScriptableObject
{
    public int level; // ini buat level berapa
    public int score; // indikasi buat jumlah bintang
    public float babyPatience; // patience nungguin di kelarin tasknya
    public float babyFulfillTime; // time pas minigame
    public float babyIntervalBetweenNeeds; // interval antara task 1 sama yg berikutnya
    public int milkShakeNeeded; // butuh berapa shake
    public int milkPowderNeeded; // butuh berapa powder
    public int babyNeedCount; // butuh berapa kebutuhan sebelum pulang
}
