using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private string _userlist = "";
    private string _adduser = "/api/add/playerinfo";

    private APIHandler API;

    private void Start()
    {
        API = this.GetComponent<APIHandler>();
    }

    private void Update()
    {
        if (API.isfetchdone())
        {
            UserID uid = new UserID();
            uid = JsonUtility.FromJson<UserID>(API.GetData());
            PlayerPrefs.SetString("Uid", uid.userid);
        }
    }
    public void getUserList()
    {
        API.fetchdata(_userlist);
    }

    public void addUser(string age,string gender)
    {
        UserInfo userinfo = new UserInfo();
        userinfo.age = age;
        userinfo.gender = gender;

        string jsonstring = JsonUtility.ToJson(userinfo);
        API.postdata(_adduser, jsonstring);
    }
}
