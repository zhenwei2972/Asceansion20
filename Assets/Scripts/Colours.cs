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
        colourlist = new List<Color>{
            Color.red,
            Color.green,
            Color.blue,
            Color.black,
            Color.yellow,
            Color.magenta
        };
        setbtncolor();
    }
    void setbtncolor()
    {
        
        foreach (Button btn in btnlist){
            int i = Random.Range(0, colourlist.Count - 1);
            btn.image.color = colourlist[i];
            colourlist.RemoveAt(i);
        }
    }

    public void getbtncolour(Button btn)
    {
        colorselected = btn.image.color;
        Debug.Log(colorselected);
    }
    public void setsectioncolor(Image img)
    {
        img.color = colorselected;
    }
}
