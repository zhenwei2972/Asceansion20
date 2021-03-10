using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameState : MonoBehaviour
{
    private int gamestate = 0;
    private Timer timer;
    private AnimationHandler Animate;
    private LevelImgInstantiate spawner;
    // Start is called before the first frame update
    public float PrimerCountDown, GameCountDown;
    public GameObject PrimerText, CountDownText;

    void Start()
    {
        timer = this.GetComponent<Timer>();
        Animate = this.GetComponent<AnimationHandler>();
        spawner = this.GetComponent<LevelImgInstantiate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestate == 0)
        {
            if (PrimerText != null && !PrimerText.Equals(null) )
            {
               
                if (timer.getCountFinish())
                {
                    //Debug.Log("Current State =" + gamestate);
                    setupTimer(PrimerText, PrimerCountDown);
                    timer.starttimer();
                    gamestate += 1;
                }
            }

        }
        if (gamestate == 1)
        {
            
            if (PrimerText != null && !PrimerText.Equals(null) && timer.getCountFinish())
                PrimerText.transform.gameObject.SetActive(false);
            if (CountDownText != null && !CountDownText.Equals(null))
            {
                if (timer.getCountFinish())
                {
                   
                    CountDownText.transform.parent.gameObject.SetActive(true);
                    setupTimer(CountDownText, GameCountDown);
                    timer.starttimer();
                    if (!spawner.isspawned())
                        spawner.SpawnImage("Easy");
                    gamestate += 1;
                }
            }
        }
        if(gamestate == 2 && timer.getCountFinish())
        {
            CountDownText.SetActive(false);
            Animate.timeup();
            // de colour image
            // play animation
            // select colour and colouring
            // submit button
            // Debug.Log("playing");
        }
    }

    void setupTimer(GameObject text , float counter)
    {
        //Debug.Log(timer.getCountFinish());
        timer.setText(text.GetComponent<TextMeshProUGUI>());
        timer.setTimer(counter);
    }
}
