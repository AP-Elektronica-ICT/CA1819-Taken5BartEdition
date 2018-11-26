﻿using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APICaller : MonoBehaviour {
    string baseURL = "https://taken5bart20181119082417.azurewebsites.net/api/";    // "Sessie/toList?id="
    string baseLocalURL = "http://localhost:1907/api/";
    public string json;

    public string ApiGet(string requestUrl)
    {
        StartCoroutine(Get(requestUrl));
        return json;
    }
    IEnumerator Get(string requestUrl)
    {
        string url = baseLocalURL + requestUrl;
        
        //Debug.Log(url);
        using (WWW www = new WWW(url))
        {
            yield return www;
            string temp = www.text;
            //Debug.Log(json == ""); json is een string en zal nooit null zijn.
            if (temp != "") //vervang null door een error waarde van de server
                json = www.text;
            else
                json = "-1";

            www.Dispose();
        }
    }



    public string ApiPost( string requestUrl, JSONNode N)
    {
        //Debug.Log(requestUrl);
        //Debug.Log(N.AsObject);
        StartCoroutine(Post(requestUrl, N));
        StartCoroutine(Wait(15));

        return json;
    }

    public IEnumerator Post(string requestUrl, JSONNode N)
    {
        Debug.Log(N.AsObject);
        string url = baseLocalURL + requestUrl;
        Debug.Log(url);
        var req = new UnityWebRequest(url, "POST");
        
            byte[] data = Encoding.UTF8.GetBytes(N.ToString());

            req.uploadHandler = new UploadHandlerRaw(data);
            req.uploadHandler.contentType = "application/json";
            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("accept", "application/json");
            req.SendWebRequest();
            yield return new WaitUntil(()=>req.downloadHandler.isDone);
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
                Debug.Log("Error");
                json = "-1";
            }
            else
            {
                var result = req.downloadHandler.text;
                Debug.Log(result + " k");
                json = result;
            }
            req.Dispose();
        
    }

    IEnumerator Wait(int s)
    {
        yield return new WaitForSeconds(s);
    }
}
