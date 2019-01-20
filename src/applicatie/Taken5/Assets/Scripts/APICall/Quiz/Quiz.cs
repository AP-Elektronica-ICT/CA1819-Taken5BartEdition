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
    static string ScoreURL = "/quizscores";

    int aantalvragen;
    int score;

    APICaller api;
    Inventory Inventory;
    Button[] buttons = new Button[6];
    Text[] Btns = new Text[6];
    BtnDisable btnDisable;
    LevelLoader levelLoader ;


    // Use this for initialization
    string json;
    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
        Inventory = gameObject.AddComponent<Inventory>();
        levelLoader = gameObject.AddComponent<LevelLoader>();

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

        url = "quiz/" + count;
        Debug.Log(url);
        WWW www = new WWW(url);
        StartCoroutine(api.Get(url, ActionGet));

    }


    void ActionGet(string jSON)
    {
        Debug.Log("ik ben json " + jSON);
        if (jSON == "-1")
        {
            Debug.Log("ik ben een -1");
            PostScore();
        }
        if (jSON != "-1")
        {
            var N = JSON.Parse(jSON);
            Debug.Log(N);
            Vraag.text = N["vraag"].Value;
            Btn1.text = N["antwoord1"].Value;
            Btn2.text = N["antwoord2"].Value;
            Btn3.text = N["antwoord3"].Value;
            Btn4.text = N["antwoord4"].Value;
            Btn5.text = N["antwoord5"].Value;
            Btn6.text = N["antwoord6"].Value;
            correctie = N["correctie"].AsInt;
            btnDisable.onclick();

            foreach (Text t in Btns)
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
        Debug.Log("poste " + score);

        JSONNode N = new JSONObject();

        N["DeviceID"] = SystemInfo.deviceUniqueIdentifier;
        N["aantalvragen"] = aantalvragen;
        N["score"] = score;

        Debug.Log("aantalvragen " + aantalvragen + "score " + score);
        
        api.ApiPost("speler/"+ Info.spelerId, N, GetTotalScore);
                         // StartCoroutine(api.Get("team/" +Info.TeamId.ToString() + "/GameDone", GetActionEndGame));



    }

    void GetTotalScore(string json)
    {
        Debug.Log("posted " + json);
        api.ApiGet("team/"+Info.TeamId+"/quizscore", GetActionEndGame);

    }
    void GetActionEndGame(string json)
    {
        Debug.Log("toptalscore" +json);
        levelLoader.ChangeGameModeEndOfGame(api, "stadsfeestzaal", double.Parse(json));

    }

}
