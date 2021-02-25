using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private GameObject Display;
    private void Start()
    {
        Display = GameObject.Find("Display");
    }
    public void playanimation() 
    {
        Display.GetComponent<AnimationHandler>().timeup();
    }

}
