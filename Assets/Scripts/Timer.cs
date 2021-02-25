using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //public variables
    public float timer, fadespeed;
    public bool StartTimer;
    public GameObject Text;

    //private variables
    private TextMeshProUGUI Counter;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        Counter = Text.GetComponent<TextMeshProUGUI>();
        Counter.text = Mathf.Round(timer).ToString();
        count = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                count = Mathf.Round(timer);
                Counter.text = count.ToString();
                if (count > timer)
                {
                    Counter.color = Color.Lerp(Counter.color, Color.clear, fadespeed * Time.deltaTime);
                }
                else
                    Counter.color = Color.Lerp(Counter.color, Color.black, fadespeed * Time.deltaTime);

            }
            else
            {
                timer = 0;
                StartTimer = false;

            }

    }
}
