using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIPost : MonoBehaviour {
    //https://answers.unity.com/questions/1419353/write-data-to-to-json-database-using-simplejsoncs.html
    // Use this for initialization
    /*
     * example van hoe je een sessie object maakt met teams in met enkel de teamnamen in
    void SessieCreator () {
        JSONNode N = new JSONObject();
        int teams = 5;
        
        N["startTijd"] = DateTime.Now.ToString();
        N["teams"][0]["teamNaam"] = "ddd";
        N["teams"][1]["teamNaam"] = "dfqa";
        Debug.Log(N);
        StartCoroutine(WWWPost(N));
    }
    */
    string baseURL = "https://taken5bart20181119082417.azurewebsites.net/api/";    // "Sessie/toList?id="
    string baseLocalURL = "http://localhost:1907/api/Sessie";
    string json;

    public string ApiPost(JSONNode aNode, string requestUrl)
    {
        StartCoroutine(Post(aNode, requestUrl));
        return json;
    } 

    public IEnumerator Post(JSONNode N, string requestUrl)
    {
        string url = baseLocalURL + requestUrl;

        var req = new UnityWebRequest(url, "POST");
        byte[] data = Encoding.UTF8.GetBytes(N.ToString());

        req.uploadHandler = new UploadHandlerRaw(data);
        req.uploadHandler.contentType = "application/json";
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("accept", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            json = "-1";
        }
        else
        {
            json = "1";
        }
        
    }
}
