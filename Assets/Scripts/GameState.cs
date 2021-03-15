﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameState : MonoBehaviour
{
    //This script is the manager of the game state running

    //scripts
    private Timer timer;
    private AnimationHandler Animate;
    private LevelImgInstantiate spawner;
    private Colours clr;
    private ColourScore scoring;
    // private var
    private List<GameObject> segments;
    private int gamestate = 0;
    //public var
    public float PrimerCountDown, GameCountDown;
    public GameObject PrimerText, CountDownText, ImgSpawner,ansImgSpawner,ScoreDisplay,GameplayInteractables,MenuInteractables;

    void Start()
    {
        timer = this.GetComponent<Timer>();
        Animate = this.GetComponent<AnimationHandler>();
        spawner = this.GetComponent<LevelImgInstantiate>();
        clr = this.GetComponent<Colours>();
        scoring = this.GetComponent<ColourScore>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gamestate)
        {
            case 0:
                if (PrimerText != null && !PrimerText.Equals(null))
                {

                    if (timer.getCountFinish())
                    {
                        setupTimer(PrimerText, PrimerCountDown);
                        timer.starttimer();
                        gamestate++;
                    }
                }
                break;
            case 1:
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
                        {
                            //below is hardcoded for now ... change "Easy" to leveloptions.level to get from mainmenu
                            //spawner.SpawnImag(leveloptions.level);
                            spawner.SpawnImage("Easy");
                            getcurrentsegments();
                            clr.setrandom(segments);
                            scoring.setans(segments);
                            EnableDisableButton(false);
                        }
                        gamestate += 1;
                    }
                }
                break;
            case 2:
                if (timer.getCountFinish())
                {
                    //getcurrentsegments();
                    GameplayInteractables.SetActive(true);
                    EnableDisableButton(true);
                    CountDownText.SetActive(false);
                    Animate.timeup();
                    clearcolour();
                    gamestate++;
                }
                break;
            case 3://wait till submit button click
                break;
            case 4:
                //display exit and play again button
                break;

        }
    }
    //below require to split into other scripts
    private void setupTimer(GameObject text, float counter)
    {
        //Debug.Log(timer.getCountFinish());
        timer.setText(text.GetComponent<TextMeshProUGUI>());
        timer.setTimer(counter);
    }
    private void getcurrentsegments()
    {
        segments = ImgSpawner.GetComponentInChildren<ColourSegment>().getsegments();
    }
    public void confirmans()
    {
        ScoreDisplay.GetComponent<TextMeshProUGUI>().text = (scoring.getscore(segments) + "%");
        ansImgSpawner.transform.parent.gameObject.SetActive(true);
        spawner.Instantiateimg(ImgSpawner.transform.GetChild(0).gameObject, ansImgSpawner);
        //disable player's ans;
        EnableDisableButton(false);
        //colour back original
        segments = new List<GameObject>();
        segments = ansImgSpawner.GetComponentInChildren<ColourSegment>().getsegments();
        clr.colorwithgivenset(segments, scoring.getans());
        
        //hide buttons.
        GameplayInteractables.SetActive(false);
        //disable ans img buttons
        EnableDisableButton(false);
        //unhide home and replay button
        MenuInteractables.SetActive(true);
        clr.clearselectedcolour();
        //play animation
        Animate.timeup();
        gamestate++;
    }
    public void clearcolour()
    {
        clr.setwhitewitharray(segments);
    }
    
    private void EnableDisableButton(bool i)
    {
        foreach(GameObject seg in segments)
        {
            seg.GetComponent<Button>().enabled = i;
        }
    }
}