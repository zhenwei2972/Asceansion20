using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{   
    public GameObject GameView;
    public void timeup()
    {
        if (GameView != null)
        {
            Animator animator = GameView.GetComponent<Animator>();
            if (animator != null)
            {
                bool TimeUp = animator.GetBool("TimeUp");
                animator.SetBool("TimeUp", !TimeUp);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
