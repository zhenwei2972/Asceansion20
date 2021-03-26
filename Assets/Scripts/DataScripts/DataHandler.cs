using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private string _adduser = "https://aseapi.hyunatic.com/public/index.php/api/add/playerinfo";
    private string _recolour = "https://aseapi.hyunatic.com/public/index.php/api/colorgame/add";
    private string _numbergame = "https://aseapi.hyunatic.com/public/index.php/api/numbergame/add";
    private string _simonsays = "https://aseapi.hyunatic.com/public/index.php/api/simonsays/add";

    private APIHandler API;
    private string state;
    private string data;
    private void Start()
    {
        API = this.GetComponent<APIHandler>();
    }

    private void Update()
    {
        switch (state) {
            case "uid":
                if (API.isfetchdone())
                {
                    data = API.GetData();
                    data = data.Trim('[', ']');
                    UserID uid = new UserID();
                    uid = JsonUtility.FromJson<UserID>(data);
                    PlayerPrefs.SetString("userid", uid.userid);
                }
                break;
        }
    }

    public void addUser(string age,string gender)
    {
        UserInfo userinfo = new UserInfo();
        userinfo.age = age;
        userinfo.gender = gender;

        string jsonstring = JsonUtility.ToJson(userinfo);
        API.postdata(_adduser, jsonstring);
        state = "uid";
    }
    public void PostColourRecallStats(string score, string img)
    {
        ReColourInfo rcInfo = new ReColourInfo();
        rcInfo.age = PlayerPrefs.GetString("age");
        rcInfo.gender = PlayerPrefs.GetString("gender");
        rcInfo.userid = PlayerPrefs.GetString("userid");
        rcInfo.mode = LevelOptions.Level;
        rcInfo.score = score;
        rcInfo.picture = img;
        Debug.Log(rcInfo.age + " | " + rcInfo.gender + "|" + rcInfo.userid + " | " + rcInfo.mode + " | " + rcInfo.score + " | " + rcInfo.picture + " | ");
        string jsonstring = JsonUtility.ToJson(rcInfo);
        API.postdata(_recolour, jsonstring);
        state = "recolour";
    }
    public void postMentalMathStats(string score)
    {
        MentalMathStats mms = new MentalMathStats();

        mms.age = PlayerPrefs.GetString("age");
        mms.gender = PlayerPrefs.GetString("gender");
        mms.userid = PlayerPrefs.GetString("userid");
        mms.mode = LevelOptions.Level;
        mms.score = score;

        string jsonstring = JsonUtility.ToJson(mms);
        API.postdata(_numbergame, jsonstring);
        state = "pmms";
    }
    public void QuickFingerStats(string score,string time)
    {
        QuickFingerStats qfs = new QuickFingerStats();

        qfs.age = PlayerPrefs.GetString("age");
        qfs.gender = PlayerPrefs.GetString("gender");
        qfs.userid = PlayerPrefs.GetString("userid");
        qfs.mode = LevelOptions.NoPlayers.ToString();
        qfs.time = time;
        qfs.score = score;

        string jsonstring = JsonUtility.ToJson(qfs);
        API.postdata(_simonsays, jsonstring);
        state = "pmms";
    }
}
