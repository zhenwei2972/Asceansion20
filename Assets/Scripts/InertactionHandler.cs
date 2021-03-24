using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InertactionHandler : MonoBehaviour
{

    private DataHandler dataHandler;

    private void start()
    {
        dataHandler = this.GetComponent<DataHandler>();
    }
    public void submituser()
    {
        string age = GameObject.Find("tmp_age").GetComponent<TMP_InputField>().text;
        TMP_Dropdown ddgender = GameObject.Find("dd_gender").GetComponent<TMP_Dropdown>();
        string gender = ddgender.options[ddgender.value].text;
        //dataHandler.addUser(age,gender,1.ToString());

        LevelOptions.GameType = "mainmenu";
        PlayerPrefs.SetInt("savedFirstTime", 1);
        
        Debug.Log(LevelOptions.GameType + PlayerPrefs.GetInt(tag));
    }

    public void removelocaldata()
    {
        PlayerPrefs.DeleteAll();
    }
}
