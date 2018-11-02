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
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            var N = JSON.Parse(json);
            Debug.Log(N);
            int count = N["count"].AsInt;
            List<string> teamNamen = new List<string>();
            for(var i =0; i < count; i++)
            {
                teamNamen.Add(N["data"][i]["teamNaam"]);
            }
            Debug.Log(teamNamen);
            www.Dispose();
        }
        dropdown.gameObject.SetActive(true);
        btnGo.gameObject.SetActive(true);
        btnJoin.gameObject.SetActive(true);

    }
}
