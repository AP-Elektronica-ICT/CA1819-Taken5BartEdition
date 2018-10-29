using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GetTeamData : MonoBehaviour {

    public string url = "http://localhost:1907/api/Speler/1/Team";
    // Use this for initialization
    public Text SpelerNaam;
    public Text TeamNaam;
    public Text Diamanten;
    public Text Score;

    IEnumerator Start()
    {
        SpelerNaam.text = "my test";
        Debug.Log("hi");
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            Debug.Log(json);
            var N = JSON.Parse(json);
            Debug.Log(N);

            Team team = JsonUtility.FromJson<Team>(json);
            
            //Debug.Log(Team team = JsonUtility.FromJson<Team>(json);); //Type casting!!!
            Debug.Log(team.spelers);
            SpelerNaam.text = N["spelers"][0]["voornaam"].Value;
            TeamNaam.text = N["teamNaam"].Value;
            Diamanten.text = N["diamantenVerzameld"].Value;
            Score.text = N["score"].Value;
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


