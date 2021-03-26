using UnityEngine;

[System.Serializable]
public class QuickFingerStats
{
    public string userid, age, gender, score, mode,time;
    public static QuickFingerStats CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<QuickFingerStats>(jsonString);
    }
}
