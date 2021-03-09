using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private GameObject Display;
    private void Start()
    {
        //this.Display = GameObject.Find("UI");
    }
    public void playanimation() 
    {
        this.Display.GetComponent<AnimationHandler>().timeup();
    }

}
