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

    IEnumerator Start()
    {
        url = "http://localhost:1907/api/Speler/" + Info.spelerId.ToString() + "/Team";
        SpelerNaam.text = "my test";
        if(Info.TeamId == -1)
        {
            Debug.Log("Dev team");
            Info.Diamanten = 1;
            Info.Score = 11111;
            TeamPositie.text = "-1";
        }
        else
        {
            using (WWW www = new WWW(url))
            {
                yield return www;
                string json = www.text;
                var N = JSON.Parse(json);
                Debug.Log(N);
                Info.SpelerNaam = N["spelers"][0]["voornaam"].Value;
                Info.TeamNaam = N["teamNaam"].Value;
                Info.Diamanten = N["diamantenVerzameld"].AsInt;
                Info.Score = N["score"].AsInt;
                Info.TeamId = N["id"].AsInt;
                www.Dispose();
            }
        }
        SpelerNaam.text = Info.SpelerNaam;
        TeamNaam.text = Info.TeamNaam;
        Diamanten.text = Info.Diamanten.ToString();
        Score.text = Info.Score.ToString();
        if(Info.TeamId != -1)
        {
            StartCoroutine(Delayed());
        }
    }
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("start2");
        var url2 = "http://localhost:1907/api/Speler/" + Info.spelerId.ToString();
        Debug.Log(url2);
        using (WWW www = new WWW(url2))
        {
            yield return www;
            var json = www.text;
            var N = JSON.Parse(json);
            Debug.Log(N);
            SpelerNaam.text = N["voornaam"].Value;
        }
   
        Debug.Log("start3");
        var url3 = "http://localhost:1907/api/Team/" + Info.TeamId.ToString() + "/GetScorePosition";
        Debug.Log(url3);
        using (WWW www = new WWW(url3))
        {
            yield return www;
            var result = www.text;
            Debug.Log(result);
            TeamPositie.text = result;
            www.Dispose();
        }
 
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


