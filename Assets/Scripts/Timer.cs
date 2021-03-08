using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //public variables
    public float fadespeed;

    

    //private variables
    private TextMeshProUGUI Counter;
    private float count, timerInput,time;
    private bool StartTimer;
    //private GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        //Counter = Text.GetComponent<TextMeshProUGUI>();
        //Counter.text = Mathf.Round(timer).ToString();
        //count = timer;
        //StartTimer = false;
    }


    //Coroutine method too fast.
    /*public IEnumerator CountDown()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1);
            displaytimer();
            timer--; 
        }
        timer = 0;

    }*/


    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        //one off timer due to time.delta Time
        if (StartTimer)
            if (timerInput > 0)
            {
                timerInput -= Time.deltaTime;
                count = Mathf.Round(timerInput);
                Counter.text = count.ToString();
                if (count > timerInput)
                {
                    Counter.color = Color.Lerp(Counter.color, Color.clear, fadespeed * Time.deltaTime);
                }
                else
                    Counter.color = Color.Lerp(Counter.color, Color.black, fadespeed * Time.deltaTime);
            }
            else
            {
                timerInput = 0;
                StartTimer = !StartTimer;
            }
    }

    public void setTimer(float n)
    {
        this.timerInput = n;
        this.displaytimer();
    }
    public void setText(TextMeshProUGUI text)
    {
        this.Counter = text;
    }
    public bool getCountFinish()
    {
        return (timerInput == 0);
    }
    public void starttimer()
    {
        this.StartTimer = true;
    }
    /*public void startcountdown()
    {
        StartCoroutine(CountDown());
    }*/
    private void displaytimer()
    {
       Counter.text = Mathf.Round(timerInput).ToString();
    }

}
