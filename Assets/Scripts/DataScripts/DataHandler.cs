using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private string _userlist = "";
    private string _adduser = "";

    private APIHandler API;

    private void Start()
    {
        API = this.GetComponent<APIHandler>();
    }
    public void getUserList()
    {
        API.fetchdata(_userlist);
    }

    public void addUser(string age,string gender,string id)
    {
        UserInfo userinfo = new UserInfo();
        userinfo.age = age;
        userinfo.gender = gender;

        string jsonstring = JsonUtility.ToJson(userinfo);
        API.postdata(_adduser, jsonstring);
    }

}
