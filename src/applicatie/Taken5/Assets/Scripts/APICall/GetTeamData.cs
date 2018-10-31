using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GetTeamData : MonoBehaviour {

    public string url = "http://localhost:1907/api/Speler/"+Info.spelerId.ToString()+"/Team";
    // Use this for initialization
    public Text SpelerNaam;
    public Text TeamNaam;
    public Text Diamanten;
    public Text Score;
    public Text TeamPositie;

    IEnumerator Start()
    {
        SpelerNaam.text = "my test";
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            var N = JSON.Parse(json);
            Debug.Log(N);

            Team team = JsonUtility.FromJson<Team>(json);
            
            //Debug.Log(Team team = JsonUtility.FromJson<Team>(json);); //Type casting!!!
            Debug.Log(team.spelers);
            SpelerNaam.text = N["spelers"][0]["voornaam"].Value;
            TeamNaam.text = N["teamNaam"].Value;
            Diamanten.text = N["diamantenVerzameld"].Value;
            Score.text = N["score"].Value;
            Info.teamId = N["id"];
            www.Dispose();
            //Start2();
        }
        Debug.Log("start2");
        var url2 = "http://localhost:1907/api/Team/" + Info.teamId.ToString() + "/GetScorePosition";
        Debug.Log(url2);
        using (WWW www = new WWW(url2))
        {
            yield return www;
            var result = www.text;
            Debug.Log(result);
            TeamPositie.text = result;
        }

    }
    IEnumerator getScorePos()
    {
        Debug.Log("start2");
        var url2 = "http://localhost:1907/api/Team/" + Info.teamId.ToString() + "/GetScorePosition";
        using (WWW www = new WWW(url2))
        {
            yield return www;
            var result = www.text;
            Debug.Log(result);
            TeamPositie.text = result;
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


