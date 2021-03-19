using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoringScript : MonoBehaviour
{
    int player1Score;
    int player2Score;
    public int increment = 20;
    public int decrement = 5;


    public int mainColor;

    public void incrementScore(int player)
    {
        if (player == 1)
        {
            player1Score += increment;
        }
        else if ( player == 2)
        {
            player2Score += increment;
        }
    }
    public void decrementScore(int player)
    {
        if (player == 1)
        {
            player1Score -= decrement;
        }
        else if (player == 2)
        {
            player2Score -= decrement;
        }
    }


    private void Update()
    {

    }
    private void Start()
    {
      
    }

}
