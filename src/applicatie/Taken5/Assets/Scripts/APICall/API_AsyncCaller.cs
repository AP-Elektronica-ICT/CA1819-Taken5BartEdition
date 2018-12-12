using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using UnityEngine;
using UnityEngine.Networking;

public class API_AsyncCaller : MonoBehaviour {
    /*
     * Het gebruik van Async en Await is onmogelijk met vuforia (.NET 3.5 vereist voor vuforia) en .NET 4 is niet backward compatible
     * 
    string baseURL = "https://taken5bart20181127090235.azurewebsites.net/api/";    // "Sessie/toList?id="
    string baseLocalURL = "http://localhost:1907/api/";



    public async Task<string> Get(string requestUrl)
    {
        string json = "-2";
        string url = baseURL + requestUrl;

        Debug.Log(url);
        var www = await new WWW(url);
        if (!string.IsNullOrEmpty(www.error))
        {
            throw new Exception();
        }
        string temp = www.text;
        //Debug.Log(json == ""); json is een string en zal nooit null zijn.
        if (temp != "") //vervang null door een error waarde van de server
            json = www.text;

        else
            json = "-1";

        Debug.Log("Get Done");
        www.Dispose();
        return json;
    }



    public async Task<string> Post(string requestUrl, JSONNode N)
    {
        string json = "-2";
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
        await req.SendWebRequest();
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
        return json;
    }
    */
}
