using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//unity Async + await ; https://github.com/tomptrs/AsyncAwait
public class APICaller : MonoBehaviour {
    string baseURL = "https://taken5bart20181219122158.azurewebsites.net/api/";    // "Sessie/toList?id="
    string baseLocalURL = "http://localhost:1907/api/";
    public string json;
    public bool isBusy;
    bool debug = false;

    public void ApiGet(string requestUrl)
    {
        isBusy = true;
        json = "-2";
        StartCoroutine(Get2(requestUrl, this.DoNothing));
    }
     //https://answers.unity.com/questions/228150/hold-or-wait-while-coroutine-finishes.html
    public void ApiGet(string requestUrl, Action<string> doLast)
    {
        json = "-2"; //-2 = niets opgehaald
        StartCoroutine(Get2(requestUrl, doLast));
    }
    /*
    public IEnumerator Get(string requestUrl, Action<string> doLast)
    {
        string url;
        if (debug)
        {
            url = baseLocalURL + requestUrl;
        }
        else
        {
            url = baseURL + requestUrl;
        }
        
        
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
            doLast(json);
            Debug.Log("Get Done");
            www.Dispose();
        }

    }
    */
    public IEnumerator Get2(string requestUrl, Action<string> doLast)
    {
        string url;
        if (debug)
        {
            url = baseLocalURL + requestUrl;
        }
        else
        {
            url = baseURL + requestUrl;
        }
        Debug.Log(url);
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("Error");
                json = "-1";
            }
            else
            {
                var result = www.downloadHandler.text;
                Debug.Log(result + " k");
                json = result;
            }
            doLast(json);
            www.Dispose();
        }
        Debug.Log("the end of GET");
    }

    public IEnumerator GetEndOfGame(string requestUrl, string locatienaam, double score, APICaller API, Action<string, string, Double, APICaller> doLast)
    {
        string url;
        if (debug)
        {
            url = baseLocalURL + requestUrl;
        }
        else
        {
            url = baseURL + requestUrl;
        }


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
            doLast(json, locatienaam, score, API);
            //Debug.Log("Get Done");
            www.Dispose();

        }
    }
        public void ApiPost(string requestUrl, JSONNode N)
    {
        json = "-2";
        StartCoroutine(Post(requestUrl, N, this.DoNothing));
    }

    public void ApiPost( string requestUrl, JSONNode N, Action<string> doLast)
    {
        json = "-2";
        StartCoroutine(Post(requestUrl, N, doLast));
    }

    public IEnumerator Post(string requestUrl, JSONNode N, Action<string> doLast)
    {
    
        string url;
        if (debug)
        {
            url = baseLocalURL + requestUrl;
        }
        else
        {
            url = baseURL + requestUrl;
        }
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
            doLast(json);
            req.Dispose();
    }

    public void ApiPut(string requestUrl, JSONNode N)
    {
        json = "-2";
        StartCoroutine(Post(requestUrl, N, DoNothing));
    }

    public IEnumerator Put(string requestUrl, JSONNode N, Action<string> doLast)
    {
        Debug.Log(N.AsObject);
        string url;
        if (debug)
        {
            url = baseLocalURL + requestUrl;
        }
        else
        {
            url = baseURL + requestUrl;
        }
        Debug.Log(url);
        var req = new UnityWebRequest(url, "PUT");

        byte[] data = Encoding.UTF8.GetBytes(N.ToString());

        req.uploadHandler = new UploadHandlerRaw(data);
        req.uploadHandler.contentType = "application/json";
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("accept", "application/json");
        req.SendWebRequest();
        yield return new WaitUntil(() => req.downloadHandler.isDone);
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
        doLast(json);
        req.Dispose();
    }

    IEnumerator Wait(int s)
    {
        yield return new WaitForSeconds(s);
    }
    void DoNothing(string json)
    {
        Debug.Log(json);
    }
}
