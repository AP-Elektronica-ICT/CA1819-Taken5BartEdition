using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

/*
 * Voor JSON pakketten die maar uit 1 laag bestaan is JsonUtility van unity zelf handig genoeg, maar voor json dat bestaat uit meerdere lagen is SimpleJSOn handiger
 */ 

public class GetTeamData : MonoBehaviour {

    public string url;
    // Use this for initialization
    public Text SpelerNaam;
    public Text TeamNaam;
    public Text Diamanten;
    public Text Score;
    public Text TeamPositie;

    private APICall api;

    void Start()
    {
        if (Info.TeamId == -1)
        {
            Debug.Log("Dev team");
            Info.Diamanten = 1;
            Info.Score = 11111;
            TeamPositie.text = "-1";
        }
        else
        {
            UpdateInfo();
            ScorePos();
        }
        
    }

    void UpdateInfo()
    {
        Info.Update();
        SpelerNaam.text = Info.SpelerNaam;
        TeamNaam.text = Info.TeamNaam;
        Diamanten.text = Info.Diamanten.ToString();
        Score.text = Info.Score.ToString();
        SpelerNaam.text = Info.Voornaam;
    }
    void ScorePos()
    {
        var url = "Team/" + Info.TeamId.ToString() + "/GetScorePosition";
        Debug.Log(url);
        var result = api.ApiCall(url);
        TeamPositie.text = result;
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


