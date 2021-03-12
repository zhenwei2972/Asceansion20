using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourScore : MonoBehaviour
{
    private List<Color> ans;

    private void Awake()
    {
        ans = new List<Color>();
    }

    public float getscore(List<GameObject> segments)
    {
        float score = 0;
        for(int i =0; i < segments.Count; i++)
        {
            //Debug.Log(ans[i]);
            if (segments[i].GetComponent<Image>().color == ans[i])
                score++;
        }
        Debug.Log((score /segments.Count) * 100);
        return (score/segments.Count) * 100;
    }
    
    public void setans(List<GameObject> segments)
    {
        foreach(GameObject seg in segments)
            ans.Add(seg.GetComponent<Image>().color);
    }
    public List<Color> getans()
    {
        return ans;
    }
}
