using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APICall : MonoBehaviour {
    string baseURL = "http://localhost:1907/api/";    // "Sessie/toList?id="
    string json;
    IEnumerator Call(string requestUrl)
    {
        string url = baseURL + requestUrl;
        
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

    public string ApiCall(string requestUrl)
    {
        StartCoroutine(Call(requestUrl));
        return json;
    }
}
