using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

/*
 * Voor JSON pakketten die maar uit 1 laag bestaan is JsonUtility van unity zelf handig genoeg, maar voor json dat bestaat uit meerdere lagen is SimpleJSOn handiger
 */ 

public class Info_GetTeamData : MonoBehaviour {

    public string url;
    // Use this for initialization
    public Text SpelerNaam;
    public Text TeamNaam;
    public Text Diamanten;
    public Text Score;
    public Text TeamPositie;
    public Text SessieCode;

    private APICaller api;
    private InfoUpdater updater;

    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
        updater = gameObject.AddComponent<InfoUpdater>();
        
        if (Info.TeamId == -1)
        {
            Debug.Log("Dev team");
            Info.Diamanten = 1;
            Info.Score = 11111;
            TeamPositie.text = "-1";
        }
        else
        {
            Debug.Log(Info.SessieCode);
            StartCoroutine(updater.UpdateInfo(api, UpdateInfo));  
        }
        
    }

    void UpdateInfo()
    {
        SpelerNaam.text = Info.SpelerNaam;
        TeamNaam.text = Info.TeamNaam;
        Diamanten.text = Info.Diamanten.ToString();
        Score.text = Info.Score.ToString();
        SpelerNaam.text = Info.Voornaam;
        SessieCode.text = Info.SessieCode;
        var url = "Team/" + Info.TeamId.ToString() + "/GetScorePosition";
        StartCoroutine(api.Get(url, ScorePos));
    }
    void ScorePos(string json)
    {
        TeamPositie.text = json;
    }

}


