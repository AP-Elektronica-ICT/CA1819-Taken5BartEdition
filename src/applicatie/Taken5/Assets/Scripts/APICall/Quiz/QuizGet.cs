using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;


public class QuizGet : MonoBehaviour
{
    public string url;
    // Use this for initialization
    public Text Vraag;
    public Text Btn1;
    public Text Btn2;
    public Text Btn3;
    public Text Btn4;
    public Text Btn5;
    public Text Btn6;
    public int count;

    
    // Use this for initialization
    string json;
    void Start()
    {
        string url = "http://localhost:1907/api/quiz/1";
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

                Debug.Log(Vraag.text);
            }

        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    
}

[System.Serializable]
public class QuizInfo
{
    public int Id { get; set; }
    public int Vraagnummer { get; set; }
    public String Vraag { get; set; }
    public String Antwoord1 { get; set; }
    public String Antwoord2 { get; set; }

    public String Antwoord3 { get; set; }
    public String Antwoord4 { get; set; }
    public String Antwoord5 { get; set; }
    public String Antwoord6 { get; set; }
    public int Correctie { get; set; }
    public int AantalKeerGeraden { get; set; }
    public bool JuistGeraden { get; set; }

    public static QuizInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<QuizInfo>(jsonString);
    }

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}
