using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Join : MonoBehaviour {

    
    public Text SessieCode;
    public Dropdown dropdown;
    public Text dropdownLabel;
    public Slider loader;

    public Button btnJoin;
    public Button btnGo;
    
    public LevelLoader levelLoader;
    public int nextLevel;
    private APICaller api;

    string url;
    List<string> teamnamen;
    Dictionary<string, int> teamlijst;

    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
    }
    public void GetTeams()
    {
        btnGo.gameObject.SetActive(false);
        string code = SessieCode.text;
        code = code.Trim('"');
        Debug.Log(code + "code");
        url = "Sessie/toList?code=" + code;
        //Debug.Log(url);
        List<string> teamnamen = new List<string>();
        teamlijst = new Dictionary<string, int>();
        if (SessieCode.text == "666") //dev bypass
        {
            teamlijst.Add("dev", -1);
            teamnamen.Add("dev");
            teamlijst.Add("Bypass", -1);
            teamnamen.Add("Bypass");
            teamlijst.Add("HAXXXX!", -1);
            teamnamen.Add("HAXXXX!");
            SetupPutInTeam();
        }
        else
        {
            StartCoroutine(api.Get(url, GetTeamResult));
        }
    }

    void GetTeamResult(string json)
    {
        Debug.Log(json);
        teamnamen = new List<string>();
        //Debug.Log(json == ""); json is een string en zal nooit null zijn.
        if (json != "-1") //vervang null door een error waarde van de server
        {
            var N = JSON.Parse(json);
            
            int count = N["count"].AsInt;
            for (var i = 0; i < count; i++)
            {
                teamlijst.Add(N["data"][i]["teamNaam"], N["data"][i]["id"].AsInt);
                teamnamen.Add(N["data"][i]["teamNaam"]);
            }
            SetupPutInTeam();
        }
        else
        {
            SessieCode.text = "wrong sessieID";
            btnGo.gameObject.SetActive(true);
        }
        
    }
    void SetupPutInTeam()
    {
        btnGo.gameObject.SetActive(true);
        dropdown.AddOptions(teamnamen);
        dropdown.gameObject.SetActive(true);
        btnJoin.gameObject.SetActive(true);
        Info.SessieCode = SessieCode.ToString();
    }

    public void PutSpelerInTeam()
    {
        btnJoin.gameObject.SetActive(false);
        btnGo.gameObject.SetActive(false);
        //get selected item from dropdown
        var menuIndex = dropdown.GetComponent<Dropdown>().value;
        var menuValue = dropdown.GetComponent<Dropdown>().options[menuIndex].text;
        Debug.Log(menuValue);

        //get teamid from the team dictionary throug the teamname
        var teamId = teamlijst[menuValue];

        //create the url for adding player
        var url = "Team/" + teamId + "/AddSpeler?spelerID=" + Info.spelerId;

        if (teamId == -1) //team id -1 => developer bypass (offline mode)
        {
            //Debug.Log("bypassing"); 
            Info.TeamNaam = menuValue;
            Info.TeamId = teamId;
            levelLoader.LoadLevel(nextLevel);
        }

        StartCoroutine(api.Get(url, NextLevel));
        
    }

    private void NextLevel(string json)
    { 
        if (json == "1")
        {
            levelLoader.LoadLevel(nextLevel);
        }
        btnJoin.gameObject.SetActive(true);
        btnGo.gameObject.SetActive(true);
    }

    public void ChangeDropValue()
    {
        var menuIndex = dropdown.GetComponent<Dropdown>().value;
        dropdownLabel.text = dropdown.GetComponent<Dropdown>().options[menuIndex].text;
    }
}
