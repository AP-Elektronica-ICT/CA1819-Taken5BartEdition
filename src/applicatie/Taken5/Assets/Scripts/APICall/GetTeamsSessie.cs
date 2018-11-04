using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTeamsSessie : MonoBehaviour {

    public string url;
    public Text SessieCode;
    public Dropdown dropdown;

    public Button btnJoin;
    public Button btnGo;

    public void Get()
    {
        StartCoroutine(GetTeams());
    }
    IEnumerator GetTeams()
    {
        btnGo.gameObject.SetActive(false);
        url = "http://localhost:1907/api/Sessie?id=" + SessieCode.text;
        Debug.Log(url);
        List<TeamList> teams = new List<TeamList>();
        List<string> teamnamen = new List<string>();
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            var N = JSON.Parse(json);
            Debug.Log(N);
            int count = N["count"].AsInt;
            
            for(var i =0; i < count; i++)
            {
                teams.Add(new TeamList { TeamNaam = N["data"][i]["teamNaam"], Id = N["data"][i]["id"] });
                teamnamen.Add(teams[i].TeamNaam);
            }
            Debug.Log(teams);
            www.Dispose();
        }
        
        dropdown.AddOptions(teamnamen);
        dropdown.gameObject.SetActive(true);
        btnGo.gameObject.SetActive(true);
        btnJoin.gameObject.SetActive(true);

    }
}

public class TeamList{
    public int Id { get; set; }
    public string TeamNaam { get; set; }
}
