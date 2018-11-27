using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class CheckDeviceId : MonoBehaviour
{

    // Use this for initialization
    static string url = "http://localhost:1907/api/speler/deviceid";

    string id;
    string voornaam;
    string achternaam;
    string deviceid;
    void Start()
    {
        Debug.Log("start");
        JSONNode N = new JSONObject();

        N["deviceId"] = SystemInfo.deviceUniqueIdentifier.ToString();
        Debug.Log(N);
        StartCoroutine(WWWPost(N));
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

    private class Speler
    {
        public double id { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string deviceid { get; set; }
    }

    // Update is called once per frame

}
