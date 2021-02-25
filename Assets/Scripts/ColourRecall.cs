using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRecall : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Gamehandler,GameDisplay;
    private int gamestate = 1;
    void Start()
    {
        Gamehandler = GameObject.Find("GameHandler");
        GameDisplay = GameObject.Find("Display");
        GameDisplay.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void state()
    {
        switch (gamestate)
        {
            case 1:
                if (Gamehandler.GetComponent<Timer>().StartTimer)
                {
                    gamestate = 2;
                } 
                    break;
                
            case 2:
                break;
            default: 
                break;
        }

    }

}
