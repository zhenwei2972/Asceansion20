using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colours : MonoBehaviour
{
    private List<Color> colourlist;
    private Color colorselected;
    public List<Button> btnlist;
    // Start is called before the first frame update
    void Start()
    {
        setcolourlist();
        setbtncolor();
    }
    void setbtncolor()
    {
        foreach (Button btn in btnlist){
            int i = Random.Range(0, colourlist.Count - 1);
            btn.image.color = colourlist[i];
            colourlist.RemoveAt(i);
        }
        setcolourlist();
    }

    public void getbtncolour(Button btn)
    {
        colorselected = btn.image.color;
        //Debug.Log(colorselected);
    }
    public void clearselectedcolour()
    {
        colorselected = Color.clear;
    }
    public void setsectioncolor(Image img)
    {
            img.color = colorselected;
    }
    public void setrandomcolor(Image img)
    {
        int i = Random.Range(0, colourlist.Count - 1);
        img.color = colourlist[i];
    }
    public void setwhitewitharray(List<GameObject> segments)
    {
        foreach(GameObject seg in segments)
        {
            setwhite(seg.GetComponent<Image>());
        }
    }
    public void setrandom(List<GameObject> segments)
    {
        foreach (GameObject seg in segments)
        {
            setrandomcolor(seg.GetComponent<Image>());
        }
    }
    public void setwhite(Image img)
    {
        img.color = Color.white;
    }

    public void colorwithgivenset(List<GameObject> segments , List<Color> ans)
    {
        for(int i = 0; i < segments.Count; i++)
        {
            segments[i].GetComponent<Image>().color = ans[i];
        }
    }

    private void setcolourlist()
    {
        colourlist = new List<Color>{
            Color.red,
            Color.green,
            Color.cyan,
            Color.grey,
            Color.yellow,
            Color.magenta
        };
    }
}
