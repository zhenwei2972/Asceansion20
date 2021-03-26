
using UnityEngine;

[System.Serializable]
public class UserID
{
    public string userid;

    public static UserID CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<UserID>(jsonString);
    }
}
