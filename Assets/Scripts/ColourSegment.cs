using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSegment : MonoBehaviour
{
    private List<GameObject> segments;
    // Start is called before the first frame update
    private Colours clr;
    void Awake()
    {        
        clr = GameObject.Find("GameHandler").GetComponent<Colours>();
        setsegments();
    }
    private void colorchange(GameObject child)
    {
        clr.setsectioncolor(child.GetComponent<Image>());
    }
    private void setsegments()
    {
        segments = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.layer == 8)
            {
                segments.Add(child.gameObject);
                child.gameObject.GetComponent<Button>().onClick.AddListener(() => colorchange(child.gameObject));
            }   
        }
        //Debug.Log(segments);
    }
    public List<GameObject> getsegments()
    {
        return segments;
    }
}
