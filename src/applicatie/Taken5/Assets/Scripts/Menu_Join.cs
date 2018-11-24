using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Join : MonoBehaviour {

    string url;
    public Text SessieCode;
    public Dropdown dropdown;
    public Text dropdownLabel;
    public Slider loader;

    public Button btnJoin;
    public Button btnGo;
    Dictionary<string, int> teamlijst;
    public LevelLoader levelLoader;
    public int nextLevel;
    private APICaller api;

    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
    }
    public void GetTeams()
    {
        btnGo.gameObject.SetActive(false);
        url = "Sessie/toList?id=" + SessieCode.text;
        bool wwwSuccess = false;
        //Debug.Log(url);
        List<string> teamnamen = new List<string>();
        teamlijst = new Dictionary<string, int>();
        if (SessieCode.text == "666") //dev bypass
        {
            wwwSuccess = true;
            teamlijst.Add("dev", -1);
            teamnamen.Add("dev");
            teamlijst.Add("Bypass", -1);
            teamnamen.Add("Bypass");
            teamlijst.Add("HAXXXX!", -1);
            teamnamen.Add("HAXXXX!");
        }
        else
        {
            string json = api.ApiGet(url);
            //Debug.Log(json == ""); json is een string en zal nooit null zijn.
            if (json != "-1") //vervang null door een error waarde van de server
            {
                wwwSuccess = true;
                var N = JSON.Parse(json);
                //Debug.Log(N);
                int count = N["count"].AsInt;
                for (var i = 0; i < count; i++)
                {
                    teamlijst.Add(N["data"][i]["teamNaam"], N["data"][i]["id"].AsInt);
                    teamnamen.Add(N["data"][i]["teamNaam"]);
                }
            }
            else
            {
                SessieCode.text = "wrong sessieID";
            }
        }
        if (wwwSuccess)
        {
            dropdown.AddOptions(teamnamen);
            dropdown.gameObject.SetActive(true);
            btnJoin.gameObject.SetActive(true);
        }
        btnGo.gameObject.SetActive(true);
    }

    public void PutSpelerInTeam()
    {
        //get selected item from dropdown
        var menuIndex = dropdown.GetComponent<Dropdown>().value;
        var menuValue = dropdown.GetComponent<Dropdown>().options[menuIndex].text;
        Debug.Log(menuValue);

        //get teamid from the team dictionary throug the teamname
        var teamId = teamlijst[menuValue];

        //create the url for adding player
        var url = "Team/" + teamId + "/AddSpeler?spelerID=" + Info.spelerId;

        string success = "0";
        if (teamId == -1) //team id -1 => developer bypass (offline mode)
        {
            //Debug.Log("bypassing"); 
            Info.TeamNaam = menuValue;
            Info.TeamId = teamId;
            success = "1";
        }
        else
        {
            success = api.ApiGet(url);
        }

        if (success == "1")
        {
            levelLoader.LoadLevel(nextLevel);
        }
    }

    public void ChangeDropValue()
    {
        var menuIndex = dropdown.GetComponent<Dropdown>().value;
        dropdownLabel.text = dropdown.GetComponent<Dropdown>().options[menuIndex].text;
    }
}
