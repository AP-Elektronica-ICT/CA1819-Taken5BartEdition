using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamListItemDisplay : MonoBehaviour {
    public Text naam;
    public Button btnDelete;

    public TeamListItem item;

    APICaller api;
    //string url = "team/" + Info.TeamId;
    string url;

	// Use this for initialization
	void Start () {
        if (item != null) Prime (item);
        btnDelete.onClick.AddListener(deletePlayer);
        api = gameObject.AddComponent<APICaller>();
        url = "speler/" + item.id + "/delete";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Prime(TeamListItem item)
    {
        this.item = item;
        if (naam != null)
            naam.text = item.naam;
    }

    void deletePlayer()
    {
        api.ApiGet(url, getAnswer);
    }

    void getAnswer(string JSON)
    {
        if(JSON == "-1")
        {
            Debug.Log("No Player Found");
        }
        else
        {
            Debug.Log(JSON);
        }
    }
}
