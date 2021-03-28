using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public GameObject btns_menu, btns_level, btns_noplayers,btn_back,FirstSetup_Menu;
    public TextMeshProUGUI Title;

    private void Start()
    {
        int firsttime = PlayerPrefs.GetInt("savedFirstTime");
        if (firsttime == 0)
        {
            LevelOptions.GameType = "setup";
        }
        else
            LevelOptions.GameType = "menu";
    }
    void Update()
    {
        switch (LevelOptions.GameType)
        {
            case "Mental_Math":
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
            case "setup":
                if(!isactive(FirstSetup_Menu))
                FirstSetup_Menu.SetActive(true);
                break;
            default:
                if (isactive(btns_level) || isactive(btns_noplayers) || isactive(FirstSetup_Menu) || !isactive(btns_menu))
                {
                    Title.text = "Memoria";
                    hidebuttons(btn_back);
                    hidebuttons(btns_level);
                    hidebuttons(btns_noplayers);
                    unhidebuttons(btns_menu);
                    hidebuttons(FirstSetup_Menu);
                }      
                break;
        }
    }

    private void unhidebuttons(GameObject btns)
    {
            btns.gameObject.SetActive(true);
    }
    private void hidebuttons(GameObject btns)
    {
            btns.gameObject.SetActive(false);
    }
    private bool isactive(GameObject btn)
    {
        return btn.gameObject.activeSelf;
    }
}
