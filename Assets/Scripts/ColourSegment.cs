using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSegment : MonoBehaviour
{
    //private List<GameObject> segments;
    // Start is called before the first frame update
    private Colours clr;
    void Start()
    {
        clr = GameObject.Find("GameHandler").GetComponent<Colours>();
        foreach(Transform child in transform)
        {
            if(child.gameObject.layer == 8)
            {
                Debug.Log(child);
                //segments.Add(child.gameObject);
                child.gameObject.GetComponent<Button>().onClick.AddListener(() => colorchange(child.gameObject));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void colorchange(GameObject child)
    {
        clr.setsectioncolor(child.GetComponent<Image>());
    }
}
