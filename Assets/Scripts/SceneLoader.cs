using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Loadgame()
    {
        SceneManager.LoadScene(LevelOptions.GameType);
    }
    public void LoadMenu()
    {
        LevelOptions.GameType = "Empty";
        SceneManager.LoadScene("MainMenu");
    }
}
