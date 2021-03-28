using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
    public int increment = 1;
    public int decrement = 0;
    public float speed = 2.0f;
    public Text winnerUI;
    public int playerNumber;
    public Text GameCompleted;
    WinningObj gameState = new WinningObj();
    public GameObject P2UI;
    public DataHandler datahandler;
    public ReactionTimer reactionTimer;
    public GameObject helpPanel;
    bool helpToggle =false;

    public void toggleHelp()
    {
        helpToggle = !helpToggle;
        helpPanel.SetActive(helpToggle);
    }
       // public bool toggleBtn = false;
    void ToggleButtons(bool toggle)
    {
      //  toggleBtn = !toggleBtn;
        for(int i =0; i <5; i++)
        {
           // Debug.Log("toggle"+toggle);
            buttons[i].GetComponent<Button>().interactable = toggle;
            p2buttons[i].GetComponent<Button>().interactable = toggle;
        }
    }
    void Start()
    {
        reactionTimer = GetComponent<ReactionTimer>();
        playerNumber = LevelOptions.NoPlayers;
        if (playerNumber == 2)
        {
            P2UI.SetActive(true);
        }
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
      //  Debug.Log("Target color is "+targetColor);
        return random;
    }
    void setupColor()
    {
       
        hash.Add(1, Color.red);
        hash.Add(2, Color.green);
        hash.Add(3, Color.blue);
        hash.Add(4, Color.yellow);
        hash.Add(5, Color.cyan);
        Color greenish = new Color(128, 0, 128);
        hash.Add(6, greenish);

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
            if (playerNumber == 2)
            {
                p2buttons[i].GetComponent<Image>().color = getRandomBtnColor(newColor);
            }
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
    void postResult()
    {
        gameState.winnerName = "Player 1";
            gameState.winnerScore = player1Score;
        Debug.Log("average time is " + reactionTimer.averageTime());
        datahandler.QuickFingerStats(player1Score.ToString(), reactionTimer.averageTime().ToString()) ;
    }
    void calculateWinner()
    {
        
        if(player1Score > player2Score)
        {
            gameState.winnerName = "Player 1";
            gameState.winnerScore = player1Score;
        }
        else if (player1Score == player2Score)
        {
            gameState.winnerName = "DRAW";
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
        ToggleButtons(false);
       
        if (targetColor == button.GetComponent<Image>().color)
        {
            if (player == 1)
            {
                // only save time if player hits the correct button.
                reactionTimer.stopTime();
                player1Score +=increment;
               // Debug.Log("P1 Correct" + button.GetComponent<Image>().color + targetColor);
            }
            else if( player ==2)
            {
                player2Score+=increment;
              // Debug.Log("P2 Correct" + button.GetComponent<Image>().color+targetColor);
            }
        }
        else
        {
            if (player == 1)
            {
                player1Score -= decrement;
             //   Debug.Log("P1 wrong " + button.GetComponent<Image>().color+targetColor);
            }
            else if (player == 2)
            {
                player2Score -= decrement;
             //   Debug.Log("P2 wrong " + button.GetComponent<Image>().color+ targetColor);
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
        GameCompleted.text = "";
        GameCompleted.gameObject.SetActive(false);
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 1)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue <= 11)
        {
            roundText.text =("Round No " + currCountdownValue);
            setColour();
            setColorBtn();
            reactionTimer.startTimer();
            yield return new WaitForSeconds(speed);
            currCountdownValue++;
            ToggleButtons(true);
            if (currCountdownValue == 11)
            {
                
                // at the end of the round post the result
                if(playerNumber ==1)
                {
                    GameCompleted.gameObject.SetActive(true);
                    GameCompleted.text = "Game Complete!";
                    postResult();
                }
                else if (playerNumber == 2)
                {
                    calculateWinner();
                }
            }
        }
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
