using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postMessage : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        string url = "http://localhost:1907/api/speler";

        WWWForm formDate = new WWWForm();
        formDate.AddField("voornaam", "sdfsd");
        formDate.AddField("achternaam", "sdf");
        formDate.AddField("deviceId", "15");


        WWW www = new WWW(url, formDate);

        StartCoroutine(request(www));
    }

    // Update is called once per frame
    IEnumerator request(WWW www)
    {
        yield return www;

    }
}