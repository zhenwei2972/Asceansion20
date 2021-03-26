using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public int random;
    public Color targetColor;
    public SpriteRenderer target;
    public GameObject[] buttons;
    public GameObject[] p2buttons;
    Dictionary<int, Color> hash = new Dictionary<int, Color>();
    public Text roundText;
    public int correctColorBtn;
    public Text player1ScoreUI;
    public Text player2ScoreUI;
    int player1Score;
    int player2Score;
    public int increment = 20;
    public int decrement = 5;
    public float speed = 1.0f;
    public Text winnerUI;
    WinningObj gameState = new WinningObj();
    void Start()
    {
        setupColor();
        StartCoroutine(StartCountdown());

    }
    public int getRandomForScoring()
    {
        return random;
    }
    void rollRandomMain()
    {

        //randomly generate a number from 1-6
        random = Random.Range(1, 5);
    }
    int getRandomLocal()
    {

        //randomly generate a number from 1-6
        return Random.Range(1, 5);

    }
    int getRandom()
    {
        int lastRand = random;
        rollRandomMain();
        while(lastRand==random)
        {
            rollRandomMain();
        }

        targetColor = hash[random];
        Debug.Log("Target color is "+targetColor);
        return random;
    }
    void setupColor()
    {
       
        hash.Add(1, Color.red);
        hash.Add(2, Color.green);
        hash.Add(3, Color.blue);
        hash.Add(4, Color.yellow);
        hash.Add(5, Color.white);
        hash.Add(6, Color.cyan);

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
        int randColor = getRandomLocal();
        int newColor = randColor;
        for (int i = 0; i < 6; i++)
        {
            if(newColor==6)
            {
                newColor = 1;
            }
            else
            {
                newColor = newColor + 1;
            }
            buttons[i].GetComponent<Image>().color = getRandomBtnColor(newColor);
            p2buttons[i].GetComponent<Image>().color = getRandomBtnColor(newColor);
        }
    }
    public int getCorrectColorBtn()
    {
        return correctColorBtn;
    }
    // Update is called once per frame
    void Update()
    {
        setScoreUI();

    }
    void calculateWinner()
    {
        
        if(player1Score > player2Score)
        {
            gameState.winnerName = "Player 1";
            gameState.winnerScore = player1Score;
        }
        else
        {
            gameState.winnerName = "Player 2";
            gameState.winnerScore = player2Score;
        }

        setWinnerUI("Winner is " + gameState.winnerName);
    }
    public void setWinnerUI(string text)
    {
        winnerUI.text = text;
    }
    public void setScoreUI()
    {
        player1ScoreUI.text = player1Score.ToString();
        player2ScoreUI.text = player2Score.ToString();
        

    }
    public void calculateScoring(int player,GameObject button)
    {
        if(targetColor == button.GetComponent<Image>().color)
        {
            if (player == 1)
            {
                player1Score+=increment;
                Debug.Log("P1 Correct" + button.GetComponent<Image>().color + targetColor);
            }
            else if( player ==2)
            {
                player2Score+=increment;
                Debug.Log("P2 Correct" + button.GetComponent<Image>().color+targetColor);
            }
        }
        else
        {
            if (player == 1)
            {
                player1Score -= decrement;
                Debug.Log("P1 wrong " + button.GetComponent<Image>().color+targetColor);
            }
            else if (player == 2)
            {
                player2Score -= decrement;
                Debug.Log("P2 wrong " + button.GetComponent<Image>().color+ targetColor);
            }
        }
    }
    public void btn1Check(int player)
    {
        calculateScoring(player, buttons[0]);
    }
    public void btn2Check(int player)
    {
        calculateScoring(player, buttons[1]);
    }
    public void btn3Check(int player)
    {
        calculateScoring(player, buttons[2]);
    }
    public void btn4Check(int player)
    {
        calculateScoring(player, buttons[3]);
    }
    public void btn5Check(int player)
    {
        calculateScoring(player, buttons[4]);
    }
    public void btn6Check(int player)
    {
        calculateScoring(player, buttons[5]);
    }
    public void btn7Check(int player)
    {
        calculateScoring(player, p2buttons[0]);
    }
    public void btn8Check(int player)
    {
        calculateScoring(player, p2buttons[1]);
    }
    public void btn9Check(int player)
    {
        calculateScoring(player, p2buttons[2]);
    }
    public void btn10Check(int player)
    {
        calculateScoring(player, p2buttons[3]);
    }
    public void btn11Check(int player)
    {
        calculateScoring(player, p2buttons[4]);
    }
    public void btn12Check(int player)
    {
        calculateScoring(player, p2buttons[5]);
    }
    public void resetGame()
    {
        player1Score = 0;
        player2Score = 0;
        setWinnerUI("");
        StartCoroutine(StartCountdown());
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            roundText.text =("Round No " + currCountdownValue);
            setColour();
            setColorBtn();
            yield return new WaitForSeconds(speed);
            currCountdownValue--;
            if(currCountdownValue == 1)
            {
                calculateWinner();
            }
        }
    }
}
