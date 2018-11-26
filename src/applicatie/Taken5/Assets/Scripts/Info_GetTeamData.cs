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

    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
        Info.updater = new InfoUpdater(api);
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
            StartCoroutine(Info.updater.UpdateInfo(UpdateInfo));
            
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
        ScorePos();
    }
    void ScorePos()
    {
        var url = "Team/" + Info.TeamId.ToString() + "/GetScorePosition";
        //Debug.Log(url);
        api.ApiGet(url, ScorePosCor);
        
    }
    void ScorePosCor()
    {
        TeamPositie.text = api.json;
    }

    [Serializable]
    private class Speler
    {
        public double id { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
    }
    [Serializable]
    private class Team
    {
        public double id { get; set; }
        public string teamNaam { get; set; }
        public List<Speler> spelers { get; set; }
        public int diamantenVerzameld { get; set; }
        public object puzzellijst { get; set; }
        public int verzameldeDiamanten { get; set; }
        public int score { get; set; }
    }
}


