using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTimer : MonoBehaviour
{
    ArrayList timer = new ArrayList();
    float avgTime = 0;
    float currTimeValue;
    float startTime;
    public bool StopTime = false;
    // Timer Debug Code.
    /*
    void Start()
    {
        startTimer();
    }
    void Update()
    {
       
        if(StopTime)
        {
            stopTime();
        }
        else
        {
            startTimer();
        }

        Debug.Log("AvgTime " + averageTime());
    }
    */
    
    //start the timer
    public void startTimer()
    {
        startTime = Time.time;
    }
    //stop the timer & add result to arraylist
    public float stopTime()
    {
        float elapsedTime = 0;
        elapsedTime = Time.time - startTime;
        storeTime(elapsedTime);
        return elapsedTime;
       // 
    }
    public void storeTime(float time)
    {
        timer.Add(time);
        Debug.Log(time);
    }
    public float averageTime()
    {
        float totalTime = 0;
        int lengthOfTimer = timer.Count;
        for(int i =0; i<timer.Count; i++)
        {
            totalTime += (float)timer[i];
        }
        avgTime = totalTime / lengthOfTimer;
        return avgTime;
    }
}
