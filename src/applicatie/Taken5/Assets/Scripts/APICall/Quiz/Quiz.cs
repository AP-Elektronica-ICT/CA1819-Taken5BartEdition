using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;
using System.Text;

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
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    int count = 1;
    int correctie;
    string url;
    static string ScoreURL = "http://localhost:1907/api/quiz/quizscores";

    int aantalvragen;
    int score;

    Button[] buttons = new Button[6];
    Text[] Btns = new Text[6];
    BtnDisable btnDisable;


    // Use this for initialization
    string json;
    void Start()
    {
        btnDisable = gameObject.AddComponent<BtnDisable>();
        btnDisable.button1 = button5;
        btnDisable.button2 = button6;
        btnDisable.x = Btn5;
        btnDisable.y = Btn6;

        Btns[0] = Btn1;
        Btns[1] = Btn2;
        Btns[2] = Btn3;
        Btns[3] = Btn4;
        Btns[4] = Btn5;
        Btns[5] = Btn6;




        buttons[0] = button1;
        buttons[1] = button2;
        buttons[2] = button3;
        buttons[3] = button4;
        buttons[4] = button5;
        buttons[5] = button6;



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
            
           // Debug.Log("WWW Ok!: " + www.text);
            json = www.text;
          
            if (www.text == "")
            {
                Debug.Log("ik ben een 0");
                PostScore();
            }
            if (json != "")
            {
                var N = JSON.Parse(json);
                Debug.Log(N);
                Vraag.text = N["vraag"].Value;
                Btn1.text= N["antwoord1"].Value;
                Btn2.text = N["antwoord2"].Value;
                Btn3.text = N["antwoord3"].Value;
                Btn4.text = N["antwoord4"].Value;
                Btn5.text = N["antwoord5"].Value;
                Btn6.text = N["antwoord6"].Value;
                correctie = N["correctie"].AsInt;
                btnDisable.onclick();

                foreach(Text t in Btns)
                {
                    if (t.text != "" && t != null)
                    {
                        aantalvragen++;
                        score++;
                    }
                }
                Debug.Log("aantal vragen" + aantalvragen);

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
            btnDisable.EnableAllButtons(buttons);
            request();

        }
        else
        { 
            switch (BtnId)
            {
                case 1:
                    btnDisable.OnWrongQuess(button1);
                    break;

                case 2:
                    btnDisable.OnWrongQuess(button2);
                    break;

                case 3:
                    btnDisable.OnWrongQuess(button3);
                    break;

                case 4:
                    btnDisable.OnWrongQuess(button4);
                    break;

                case 5:
                    btnDisable.OnWrongQuess(button5);
                    break;

                case 6:
                    btnDisable.OnWrongQuess(button6);
                    break;

            }
            score -= 1;     
            Debug.Log("score is " + score);
        }

    }

    void PostScore()
    {
        JSONNode N = new JSONObject();

        N["DeviceId"] = "";
        N[aantalvragen] = aantalvragen;
        N[score] = score;

        StartCoroutine(WWWPost(N));
    }

    public static IEnumerator Post(JSONNode aNode)
    {
        var req = new UnityWebRequest(ScoreURL, "POST");
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
        {
            var req = new UnityWebRequest(ScoreURL, "POST");
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

}

