using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public GameObject btns_menu, btns_level, btns_noplayers,btn_back,FirstSetup_Menu;
    public TextMeshProUGUI Title;
    void Update()
    {
        if (PlayerPrefs.GetInt(tag) != 0)
        {
            LevelOptions.GameType = "setup";
        }
        //Debug.Log(LevelOptions.GameType);
        switch (LevelOptions.GameType)
        {
            case "Colour_Recall":
                if (isactive(btns_menu))
                {
                    hidebuttons(btns_menu);
                    unhidebuttons(btns_level);
                    Title.text = "Difficulty";
                    unhidebuttons(btn_back);
                }
                break;
            case "Quick_Finger":
                if (isactive(btns_menu))
                {
                    hidebuttons(btns_menu);
                    unhidebuttons(btns_noplayers);
                    Title.text = "Number of Players";
                    unhidebuttons(btn_back);
                }
                break;
            case "Mental_Math":
                LoadScene();
                break;
            case "setup":
                FirstSetup_Menu.SetActive(true);
                break;
            default:
                if (isactive(btns_level) || isactive(btns_noplayers))
                {
                    Title.text = "Memoria";
                    hidebuttons(btn_back);
                    hidebuttons(btns_level);
                    hidebuttons(btns_noplayers);
                    unhidebuttons(btns_menu);
                    FirstSetup_Menu.SetActive(false);
                }      
                break;
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(LevelOptions.GameType);
    }
    public void setGametype(Button btn)
    {
        LevelOptions.GameType = btn.name;
    }
    public void setDifficulty(Button btn)
    {
        LevelOptions.Level = btn.GetComponentInChildren<TextMeshProUGUI>().text;
        LoadScene();
    }
    private void unhidebuttons(GameObject btns)
    {
            btns.gameObject.SetActive(true);
    }
    private void hidebuttons(GameObject btns)
    {
            btns.gameObject.SetActive(false);
    }
    public void setnumplayers(Button btn)
    {
        LevelOptions.NoPlayers = int.Parse(btn.name);
        LoadScene();
    }
    private bool isactive(GameObject btn)
    {
        return btn.gameObject.activeSelf;
    }
}
