using UnityEngine;

[System.Serializable]
public class ReColourInfo
{
    public string age, score, picture, mode, userid, gender;
    public static ReColourInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReColourInfo>(jsonString);
    }
}
