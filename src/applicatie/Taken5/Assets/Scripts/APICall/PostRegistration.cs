using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRegistration : MonoBehaviour {

    public Input Voornaam;
    public Input Achternaam;
	// Use this for initialization
	void Start () 
    {
        string url = "";
        WWWForm formDate = new WWWForm();
        formDate.AddField("Voornaam", "Viktor");
        formDate.AddField("Achternaam", "Segers");

        WWW www = new WWW(url, formDate);
		
	}
	
    IEnumerator request (WWW www)
    {
        yield return www;

    }
}
