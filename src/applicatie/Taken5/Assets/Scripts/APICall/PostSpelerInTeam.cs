using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PutSpelerInTeam : MonoBehaviour {
    Dropdown dropdown;

	// Use this for initialization
	void Start () {
        StartCoroutine(Upload());
	}
	IEnumerator Upload()
    {

        var teamId = 0;
        var url = "http://localhost:1907/api/Team/"+teamId+"/AddSpeler?spelerID="+Info.spelerId;
        using(WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
