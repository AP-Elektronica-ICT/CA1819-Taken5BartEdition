using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;


public class Quiz : MonoBehaviour
{
    // Use this for initialization
    public Text Vraag;
    public Text Btn1;
    public Text Btn2;
    public Text Btn3;
    public Text Btn4;
    public Text Btn5;
    public Text Btn6;
    int count = 1;
    int correctie;
    string url;


    // Use this for initialization
    string json;
    void Start()
    {
        request();
        
    }
    void request()
    {
        url = "http://localhost:1907/api/quiz/" + count;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            json = www.text;
            if (json != "")
            {
                var N = JSON.Parse(json);
                Debug.Log(N);
                Vraag.text = N["vraag"].Value;
                Btn1 .text= N["antwoord1"].Value;
                Btn2.text = N["antwoord2"].Value;
                Btn3.text = N["antwoord3"].Value;
                Btn4.text = N["antwoord4"].Value;
                Btn5.text = N["antwoord5"].Value;
                Btn6.text = N["antwoord6"].Value;
                correctie = N["correctie"].AsInt;
                
            }

        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    public void onlick(int BtnId)
    {
        if (BtnId == correctie)
        {
            Debug.Log("juist");
            count++;
            request();

        }
    }
}

