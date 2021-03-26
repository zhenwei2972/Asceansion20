using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColouringGame : MonoBehaviour
{
    private Timer timer;
    private LevelImgInstantiate spawner;
    private Colours clr;
    private ColourScore scoring;
    public List<GameObject> segments;
    private GameState gs;
    private float score;
    ReColourInfo RCinfo;
    private void Start()
    {
        timer = this.GetComponent<Timer>();
        spawner = this.GetComponent<LevelImgInstantiate>();
        clr = this.GetComponent<Colours>();
        scoring = this.GetComponent<ColourScore>();
        gs = this.GetComponent<GameState>();
    }
    public void setupTimer(GameObject text, float counter)
    {
        timer.setText(text.GetComponent<TextMeshProUGUI>());
        timer.setTimer(counter);
        timer.starttimer();
    }
    public void getcurrentsegments(GameObject ImgSpawner)
    {
        segments = ImgSpawner.GetComponentInChildren<ColourSegment>().getsegments();
    }
    public void clearcolour()
    {
        clr.setwhitewitharray(segments);
    }

    public void confirmans()
    {
        gs.gamestate = 3;
        score = scoring.getscore(segments);
        gs.ScoreDisplay.GetComponent<TextMeshProUGUI>().text = (score + "%");
        spawner.Instantiateimg(gs.ImgSpawner.transform.GetChild(0).gameObject, gs.ansImgSpawner);
        //disable player's ans;
        EnableDisableButton(false);
        //colour back original
        segments = new List<GameObject>();
        segments = gs.ansImgSpawner.GetComponentInChildren<ColourSegment>().getsegments();
        clr.colorwithgivenset(segments, scoring.getans());
        //disable ans img buttons
        EnableDisableButton(false);

    }

    public float setdifficulty()
    {
        Debug.Log(LevelOptions.Level);
        switch (LevelOptions.Level)
        {
            case "Easy":
                Debug.Log("Run1");
                return 10;
            case "Medium":
                Debug.Log("Run2");
                return 8;
            case "Hard":
                Debug.Log("Run3");
                return 5;
            default:
                return 3;
        }
    }
    public void EnableDisableButton(bool i)
    {
        foreach (GameObject seg in segments)
        {
            seg.GetComponent<Button>().enabled = i;
        }
    }
    public float getscore()
    {
        return score;
    }
}
