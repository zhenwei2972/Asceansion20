using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;
using UnityEngine;

public class APIHandler : MonoBehaviour
{
    //public string postdata;
    //post data must be in json format entire string must be = {"param1":"value","param2":"value"}
    //public string _postlink;
    //public string _getlink;
    // Start is called before the first frame update
    private string data;
    private float progress;
    void Start()
    {
        //StartCoroutine(GetRequest(_getlink));
        //StartCoroutine(Post(url,param1)); 
    }

    public void postdata(string _postlink,string postdata)
    {
        progress = 0f;
        StartCoroutine(Post(_postlink, postdata));
    }
    public void fetchdata(string _getlink)
    {
        progress = 0f;
        StartCoroutine(GetRequest(_getlink));
    }
    IEnumerator Post(string url, string bodyJsonString)
    {
        Debug.Log("Post called");
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Error :" + request.error);
        }
        else
        {
            //string j = request.uploadHandler.data.ToString();
            data = request.downloadHandler.text;
            progress = request.downloadProgress;
            Debug.Log("Success" + data);
        } 
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        { 
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                data = webRequest.downloadHandler.text;
                progress = webRequest.downloadProgress;

                Debug.Log("Success : " + data);
                //byte[] result = webRequest.downloadHandler.data;
                
                //convert raw bytes to json
                //byte[] bConvert = System.Text.UnicodeEncoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.Unicode, result);

                //string text = System.Text.Encoding.Unicode.GetString(bConvert);
                //Debug.Log(text);

                //Debug.Log(pages[page] + ":\nReceived: " + data);

            }
        }
    }
    public string GetData()
    {
        //Debug.Log("getData :" + data);
        return data;
    }

    public bool isfetchdone()
    {
        if (progress == 1f)
            return true;
        else
            return false;
    }
}
