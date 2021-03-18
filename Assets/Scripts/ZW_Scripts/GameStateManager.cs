using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public int random;
    public SpriteRenderer target;
    public GameObject[] buttons;
    Dictionary<int, Color> hash = new Dictionary<int, Color>();
    void Start()
    {
        setupColor();
        StartCoroutine(StartCountdown());
    }
    void rollRandomMain()
    {
        System.Random randomGenerator = new System.Random();
        //randomly generate a number from 1-6
        random = randomGenerator.Next(1, 7);
    }
    int getRandomLocal()
    {
        System.Random randomGenerator2 = new System.Random();
        //randomly generate a number from 1-6
        return randomGenerator2.Next(1, 7);

    }
    int getRandom()
    {
        rollRandomMain();
        Debug.Log(random);
        return random;
    }
    void setupColor()
    {
       
        hash.Add(1, Color.red);
        hash.Add(2, Color.green);
        hash.Add(3, Color.blue);
        hash.Add(4, Color.yellow);
        hash.Add(5, Color.white);
        hash.Add(6, Color.gray);

    }
    Color getRandomColor()
    {
        return hash[getRandom()];
    }
    Color getRandomBtnColor(int randColor)
    {
        return hash[randColor];
    }

    void setColour()
    {
        target.color = getRandomColor();
    }

//Set Color of buttons 
    void setColorBtn()
    {
        for (int i = 0; i < 6; i++)
        {
            int randColor = getRandomLocal();
            buttons[i].GetComponent<Image>().color = getRandomBtnColor(randColor);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            setColour();
            setColorBtn();
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }
}
