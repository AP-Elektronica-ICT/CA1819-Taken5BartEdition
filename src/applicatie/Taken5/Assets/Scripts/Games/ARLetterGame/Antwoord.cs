using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Antwoord : MonoBehaviour {
    private string opl = "aliens";
    public Text txtAntwoord;
    public Text inAntwoord;
    public GameObject delijn;
    public GameObject kruitvat;
    public GameObject ASAdventure;
    public GameObject Hema;
    public GameObject Score;
    public GameObject JaJ;
    public Button btnTryAnswer;
    public Image correct;
    public Image wrong;

    private APICaller _api;
    private bool _updating;
    DateTime starttijd;
    LevelLoader levelLoader;
    int guesses;

    // Use this for initialization
    void Start () {
        guesses = 0;
        //Info.TeamId = 2;
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        starttijd = DateTime.Now;


        StartCoroutine(_api.Put("Team/" + Info.TeamId + "/SetActivePuzzel?reset=false",new JSONObject(), result));
        _updating = true;
        txtAntwoord.text = opl.ToUpper();
        var charopl = opl.ToCharArray();
        setupText(delijn.GetComponentsInChildren<TextMesh>(true), charopl[0]);
        setupText(kruitvat.GetComponentsInChildren<TextMesh>(true), charopl[1]);
        setupText(ASAdventure.GetComponentsInChildren<TextMesh>(true), charopl[2]);
        setupText(Hema.GetComponentsInChildren<TextMesh>(true), charopl[3]);
        setupText(Score.GetComponentsInChildren<TextMesh>(true), charopl[4]);
        setupText(JaJ.GetComponentsInChildren<TextMesh>(true), charopl[5]);
        
    }

    void result(string json)
    {
        Debug.Log(json);
        if(json == "-1")
        {
            Debug.Log("returning to nav");
            backToNav("-1");
        }
        else
        {
            var N = JSON.Parse(json);
            Debug.Log(N["id"].Value);
            StartCoroutine(resetUpdate());
        }
    }

    IEnumerator resetUpdate()
    {
        yield return new WaitForSeconds(5);
        _updating = false;
    }

    void Update()
    {
        if (!_updating)
        {
            _updating = true;
            StartCoroutine(_api.Get2("Team/" + Info.TeamId + "/ActivePuzzel", result));
        }
    }

    void setupText(TextMesh[] texts, char c)
    {
        texts[0].text = c.ToString();
        texts[1].text = c.ToString();
    }
	
	public void Answer()
    {
        btnTryAnswer.gameObject.SetActive(false);
        guesses++;
        string user = inAntwoord.text.ToLower();
        if(opl == user)
        {
            Debug.Log("correct");
            StartCoroutine(_api.Put("Team/" + Info.TeamId + "/SetActivePuzzel?reset=true", new JSONObject(), backToNav));
            correct.gameObject.SetActive(true);
        }
        else
        {
            wrong.gameObject.SetActive(true);
            StartCoroutine(delayInput());
        }
    }

    IEnumerator delayInput()
    {
        yield return new WaitForSeconds(10);
        correct.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);
        btnTryAnswer.gameObject.SetActive(true);
    }
    void backToNav(string json)
    {
        var timeresult = (DateTime.Now - starttijd).Minutes;
        float finalResult = 0;
        if (timeresult < 3)
        {
            finalResult = 10;
        }
        else if (timeresult < 8)
        {
            finalResult = 13 - timeresult;
        }
        else if (timeresult < 13)
        {
            finalResult = 5 - ((timeresult - 8) * 0.5f);
        }
        else
        {
            finalResult = 0;
        }
        finalResult = finalResult - (guesses * 0.25f);
        Debug.Log("all found");
        levelLoader.ChangeGameModeEndOfGame(_api, "meir", finalResult);
    }
}
