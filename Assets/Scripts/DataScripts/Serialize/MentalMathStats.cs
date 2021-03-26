using UnityEngine;

[System.Serializable]
public class MentalMathStats
{
    public string userid, age, gender,score,mode;
    public static MentalMathStats CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MentalMathStats>(jsonString);
    }
}
