using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APICaller : MonoBehaviour {
    string baseURL = "https://taken5bart20181119082417.azurewebsites.net/api/";    // "Sessie/toList?id="
    string baseLocalURL = "http://localhost:1907/api/";
    public string json;
    public bool isBusy;

    public string ApiGet(string requestUrl)
    {
        isBusy = true;
        json = "-2";
        StartCoroutine(Get(requestUrl, this.DoNothing));
        return json;
    }
     //https://answers.unity.com/questions/228150/hold-or-wait-while-coroutine-finishes.html
    public string ApiGet(string requestUrl, Action doLast)
    {
        json = "-2"; //-2 = niets opgehaald
        StartCoroutine(Get(requestUrl, doLast));
        return json;
    }
    
    public IEnumerator Get(string requestUrl, Action doLast)
    {
        string url = baseURL + requestUrl;
        
        Debug.Log(url);
        using (WWW www = new WWW(url))
        {
            yield return www;
            string temp = www.text;
            //Debug.Log(json == ""); json is een string en zal nooit null zijn.
            if (temp != "") //vervang null door een error waarde van de server
                json = www.text;
                
            else
                json = "-1";
            isBusy = false;
            doLast();
            Debug.Log("Get Done");
            www.Dispose();
            
        }

    }

    public string ApiPost(string requestUrl, JSONNode N)
    {
        json = "-2";
        StartCoroutine(Post(requestUrl, N, this.DoNothing));
        return json;
    }

    public string ApiPost( string requestUrl, JSONNode N,Action doLast)
    {
        json = "-2";
        StartCoroutine(Post(requestUrl, N, doLast));
        return json;
    }

    public IEnumerator Post(string requestUrl, JSONNode N, Action doLast)
    {
        Debug.Log(N.AsObject);
        string url = baseURL + requestUrl;
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
            doLast();
            req.Dispose();
        
    }

    IEnumerator Wait(int s)
    {
        yield return new WaitForSeconds(s);
    }
    void DoNothing()
    {
        var i = 1 + 1;
    }
}
