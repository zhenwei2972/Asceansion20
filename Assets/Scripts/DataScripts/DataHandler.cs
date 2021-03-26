using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private string _adduser = "https://aseapi.hyunatic.com/public/index.php/api/add/playerinfo";
    private string _recolour = "https://aseapi.hyunatic.com/public/index.php/api/colorgame/add";

    private APIHandler API;
    private string state;
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
                    UserID uid = new UserID();
                    uid = JsonUtility.FromJson<UserID>(API.GetData());
                    PlayerPrefs.SetString("Uid", uid.userid);
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
    public void ColourRecall(ReColourInfo rc)
    {
        string jsonstring = JsonUtility.ToJson(rc);
        API.postdata(_recolour, jsonstring);
        state = "recolour";
    }
}
