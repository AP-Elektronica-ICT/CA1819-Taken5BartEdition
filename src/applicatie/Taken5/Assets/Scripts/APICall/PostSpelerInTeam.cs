using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostSpelerInTeam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Upload());
	}
	IEnumerator Upload()
    {
        var url = "http://localhost:1907/api/Team/"+5+"/AddSpeler?spelerID="+6;
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            UnityWebRequest www = Uweb;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
