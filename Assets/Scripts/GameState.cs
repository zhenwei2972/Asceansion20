using System.Collections;
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
    private ColouringGame colouringGame;
    private ScreenShotHandler schandler;
    private DataHandler dataHandler;

    //public var
    public int gamestate = 0;
    public float PrimerCountDown, GameCountDown;
    public GameObject PrimerText, CountDownText, ImgSpawner,ansImgSpawner,ScoreDisplay,GameplayInteractables,MenuInteractables;

    void Start()
    {
        dataHandler = this.GetComponent<DataHandler>();
        schandler = this.GetComponent<ScreenShotHandler>();
        timer = this.GetComponent<Timer>();
        Animate = this.GetComponent<AnimationHandler>();
        spawner = this.GetComponent<LevelImgInstantiate>();
        clr = this.GetComponent<Colours>();
        scoring = this.GetComponent<ColourScore>();
        colouringGame = this.GetComponent<ColouringGame>();
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
                        colouringGame.setupTimer(PrimerText, PrimerCountDown);
                        gamestate = 1;
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
                        colouringGame.setdifficulty();
                        colouringGame.setupTimer(CountDownText, GameCountDown);
                        if (!spawner.isspawned())
                        {
                            //below is hardcoded for now ... change "Easy" to leveloptions.level to get from mainmenu
                            //spawner.SpawnImag(leveloptions.level);
                            spawner.SpawnImage("Easy");
                            colouringGame.getcurrentsegments(ImgSpawner);
                            clr.setrandom(colouringGame.segments);
                            scoring.setans(colouringGame.segments);
                            colouringGame.EnableDisableButton(false);
                        }
                        gamestate = 2;
                    }
                }
                break;
            case 2:
                if (timer.getCountFinish())
                {
                    //getcurrentsegments();
                    GameplayInteractables.SetActive(true);
                    colouringGame.EnableDisableButton(true);
                    CountDownText.SetActive(false);
                    Animate.timeup();
                    colouringGame.clearcolour();
                    gamestate = 5;
                }
                break;
            case 3:
                ansImgSpawner.transform.parent.gameObject.SetActive(true);
                //hide buttons.
                GameplayInteractables.SetActive(false);
                //play animation
                Animate.timeup();
                //unhide home and replay button
                clr.clearselectedcolour();
                if (Animate.hasplayed())
                {
                    schandler.screenshot();
                    ReColourInfo rcinfo = colouringGame.gamestats();
                    rcinfo.picture = schandler.imgbytes;
                    dataHandler.ColourRecall(rcinfo);
                    gamestate += 1;
                }
                break;
            case 4:
                MenuInteractables.SetActive(true);
                break;
            default:
                break;
        }
    }
}