using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
public static class JsonHelper
{
    public static T[] FromJson<T>(string jsonstring)
    {
        jsonstring = jsonstring.Trim('[', ']');
        string delimiter = "(?<=[}])";
        var json = Regex.Split(jsonstring,delimiter);
        json = json.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        
        //Debug.Log(json.Length);
        T[] wrapper = new T[json.Length];
        //Debug.Log(jsonstring);
        for(int i = 0; i < json.Length; i++)
        {
            if(json[i][0] == ',')
            {
                json[i] = json[i].Substring(1);
            }
            wrapper[i] = JsonUtility.FromJson<T>(json[i]);
        }
        return wrapper;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}