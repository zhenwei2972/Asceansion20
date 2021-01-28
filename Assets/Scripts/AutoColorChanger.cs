using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public Color start;
    public Color end;
    float starttime;
    void Start()
    {
        starttime = Time.time;
    }
    Color lerpedColor = Color.red;
    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - starttime) * speed;
        GetComponent<Text>().color = Color.Lerp(start,end,t);
    }
}
