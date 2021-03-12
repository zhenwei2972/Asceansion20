using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public GameObject btns_menu, btns_level, btns_noplayers;
    public TextMeshProUGUI Title;
    void Update()
    {
        //Debug.Log(LevelOptions.GameType);
        switch (LevelOptions.GameType)
        {
            case "Colour_Recall":
                if (isactive(btns_menu))
                {
                    hidebuttons(btns_menu);
                    unhidebuttons(btns_level);
                    Title.text = "Difficulty";
                }
                break;
            case "Quick_Finger":
                if (isactive(btns_menu))
                {
                    hidebuttons(btns_menu);
                    unhidebuttons(btns_noplayers);
                    Title.text = "Number of Players";
                }
                break;
            case "Mental_Math":
                LoadScene();
                break;
            default:
                if (isactive(btns_level) || isactive(btns_noplayers))
                {
                    hidebuttons(btns_level);
                    hidebuttons(btns_noplayers);
                    unhidebuttons(btns_menu);
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
