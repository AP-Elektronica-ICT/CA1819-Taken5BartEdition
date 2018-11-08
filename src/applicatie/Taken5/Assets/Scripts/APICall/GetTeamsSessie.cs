using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTeamsSessie : MonoBehaviour {

    string url;
    public Text SessieCode;
    public Dropdown dropdown;
    public Text dropdownLabel;

    public Button btnJoin;
    public Button btnGo;
    Dictionary<string, int> teamlijst = new Dictionary<string, int>();
    public LevelLoader levelLoader;
    public int nextLevel;

    public void Get()
    {
        StartCoroutine(GetTeams());
    }
    IEnumerator GetTeams()
    {
        btnGo.gameObject.SetActive(false);
        url = "http://localhost:1907/api/Sessie?id=" + SessieCode.text;
        Debug.Log(url);
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
                teamlijst.Add(N["data"][i]["teamNaam"], N["data"][i]["id"].AsInt);
                teamnamen.Add(N["data"][i]["teamNaam"]);
            }
            //Debug.Log(teams);
            www.Dispose();
        }
        
        dropdown.AddOptions(teamnamen);
        dropdown.gameObject.SetActive(true);
        btnGo.gameObject.SetActive(true);
        btnJoin.gameObject.SetActive(true);

    }

    public void PutSpelerInTeam()
    {
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        var menuIndex = dropdown.GetComponent<Dropdown>().value;
        var menuValue = dropdown.GetComponent<Dropdown>().options[menuIndex].text;
        Debug.Log(menuValue);
        var teamId = teamlijst[menuValue];
        
        
        var url = "http://localhost:1907/api/Team/" + teamId + "/AddSpeler?spelerID=" + Info.spelerId;
        string success = "0";
        using (WWW www = new WWW(url))
        {
            yield return www;
            success = www.text;
        }
        if(success == "1")
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
