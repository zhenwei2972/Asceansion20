using UnityEngine;

[System.Serializable]
public class UserInfo
{
    public string id,age,gender;
    public static UserInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<UserInfo>(jsonString);
    }
}
