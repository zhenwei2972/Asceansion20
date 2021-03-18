using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject colorTarget;
    public GameObject Player1Buttons;
    public GameObject Player2Buttons;
    public GameObject test;
    private int randomNumber;
    public Color targetColour;
    public Color[] colors= {Color.red,Color.green,Color.green,Color.yellow,Color.white,Color.black };
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i =0; i <Player1Buttons.transform.childCount;)
        {
            /*
            randomNumber = getRandColor();
            GameObject child = Player1Buttons.transform.GetChild(i).gameObject;
            child.GetComponent<Image>().color = colors[randomNumber];
            */
            Debug.Log(Player1Buttons.transform.GetChild(i).gameObject);

        }
        
        colorTarget.GetComponent<SpriteRenderer>().color = colors[getRandColor()];

    }

    int getRandColor()
    {
        randomNumber =Random.Range(0, 5);
        return randomNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
