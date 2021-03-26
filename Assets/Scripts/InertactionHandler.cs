using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.SetString("Age", age);
        PlayerPrefs.SetString("Gender", gender);
    }

    public void removelocaldata()
    {
        PlayerPrefs.DeleteAll();
    }

    public void setGametype()
    {
        LevelOptions.GameType = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
    }
    public void setDifficulty()
    {
        LevelOptions.Level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        LoadScene();
    }
    public void setnumplayers()
    {
        LevelOptions.NoPlayers = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name);
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(LevelOptions.GameType);
    }
}
