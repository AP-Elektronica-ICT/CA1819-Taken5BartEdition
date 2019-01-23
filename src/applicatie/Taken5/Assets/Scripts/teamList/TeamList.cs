using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class TeamList : MonoBehaviour {
    public List<TeamListItem> items = new List<TeamListItem>();
    public TeamListDisplay teamListDisplay;
    TeamListDisplay inventory;

    APICaller api;
    string url = "team/" + Info.TeamId;

    // Use this for initialization
    void Start () {
        inventory = (TeamListDisplay)Instantiate(teamListDisplay);
        api = gameObject.AddComponent<APICaller>();
        api.ApiGet(url, getPlayers);
    }
	
    void getPlayers(string json)
    {
        var N = JSON.Parse(json);
        foreach(JSONNode player in N["spelers"])
        {
            addPlayer(player["voornaam"].Value.ToString(), Int32.Parse(player["id"].Value));
        }
        inventory.Prime(items);
    }

    public void addPlayer(string naam, int id)
    {
        Debug.Log("naam " + naam);
        TeamListItem item = gameObject.AddComponent<TeamListItem>();
        item.naam = naam;
        item.id = id;
        items.Add(item);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
