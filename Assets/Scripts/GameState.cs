using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                            spawner.SpawnImage("Easy");
                            getcurrentsegments();
                            clr.setrandom(segments);
                            scoring.setans(segments);
                        }
                        gamestate += 1;
                    }
                }
                break;
            case 2:
                if (timer.getCountFinish())
                {
                    //getcurrentsegments();
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
        //colour back original
        segments = new List<GameObject>();
        segments = ansImgSpawner.GetComponentInChildren<ColourSegment>().getsegments();
        clr.colorwithgivenset(segments, scoring.getans());

        //hide buttons.
        GameplayInteractables.SetActive(false);
        //unhide home and replay button
        MenuInteractables.SetActive(true);
        clr.clearselectedcolour();
        //play animation
        gamestate++;
    }
    public void clearcolour()
    {
        clr.setwhitewitharray(segments);
    }
}