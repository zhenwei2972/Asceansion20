using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timer = 10;
    public bool StartTimer = false;
    public Sprite[] timerimg;
    public GameObject GameView;
    // Start is called before the first frame update

    Text Counter;
    Image Clock;
    float count = 0;
    int currentimg = 0;
    void Start()
    {
        StartTimer = true;
        Counter = GameObject.Find("Counter").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Image>();
        Counter.text = Mathf.Round(timer).ToString();
        count = timer;
        currentimg = timerimg.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
            if (timer > 0)
            {
                Clock.sprite = timerimg[(int)(timerimg.Length - currentimg)];
                timer -= Time.deltaTime;
                if(count > Mathf.Round(timer))
                {
                    currentimg--;
                }
                count = Mathf.Round(timer);
                Counter.text = count.ToString();
            }
            else 
            {
                timer = 0;
                StartTimer = false;
                Clock.sprite = timerimg[0];
                GameView.GetComponent<AnimationHandler>().timeup();
            }
    }
}
