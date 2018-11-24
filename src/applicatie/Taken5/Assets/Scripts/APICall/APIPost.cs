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
    void Start () {
        JSONNode N = new JSONObject();
        int teams = 5;
        
        N["startTijd"] = DateTime.Now.ToString();
        N["teams"][0]["teamNaam"] = "ddd";
        N["teams"][1]["teamNaam"] = "dfqa";
        Debug.Log(N);
        StartCoroutine(WWWPost(N));
    }
    static string url = "http://localhost:1907/api/Sessie";
    public static IEnumerator Post(JSONNode aNode)
    {
        var req = new UnityWebRequest(url, "POST");
        byte[] data = Encoding.UTF8.GetBytes(aNode.ToString());

        req.uploadHandler = new UploadHandlerRaw(data);
        req.uploadHandler.contentType = "application/json";
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("accept", "application/json");
        yield return req.SendWebRequest();
        string blobURL = req.GetResponseHeader("Location");
        Debug.Log(blobURL);
        
    }

    public static IEnumerator WWWPost(JSONNode N)
    {
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
            Debug.Log(req.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
