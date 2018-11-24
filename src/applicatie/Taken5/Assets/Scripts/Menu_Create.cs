using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Create : MonoBehaviour {
    int aantalTeams;
    int teamCounter;
    List<string> teamNamen;
    private APICaller api;

    public InputField txtAantalGroepen;
    public InputField txtTeamNaam;

    public Button btnInitSessie;
    public Button btnAddTeam;
    public Button btnStartSesstion;

    public Image recapTeams;
    public Text txtTeam;
    

    // Use this for initialization
    void Start()
    {
        btnInitSessie.gameObject.SetActive(true);
        txtAantalGroepen.gameObject.SetActive(true);
        btnAddTeam.gameObject.SetActive(false);
        txtTeamNaam.gameObject.SetActive(false);
        recapTeams.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(false);
        btnStartSesstion.gameObject.SetActive(false);
        api = gameObject.AddComponent<APICaller>();
    }
    public void SessieInit()
    {
        Debug.Log("sessieInit");
        aantalTeams = int.Parse(txtAantalGroepen.text);
        Debug.Log(aantalTeams);
        if (aantalTeams > 0 && aantalTeams < 5)
        {
            Debug.Log("hi");
            teamNamen = new List<string>();
            btnInitSessie.gameObject.SetActive(false);
            txtAantalGroepen.gameObject.SetActive(false);
            btnAddTeam.gameObject.SetActive(true);
            txtTeamNaam.gameObject.SetActive(true);
            teamCounter = 0;
        }
        else
            txtAantalGroepen.text = "Aantal Groepen";
    }

    public void AddTeam()
    {
        Debug.Log("addTeams");
        string teamNaam = txtTeamNaam.text;
        teamNamen.Add(teamNaam);
        teamCounter++;
        Debug.Log(teamCounter);
        if (teamCounter >= aantalTeams)
        {
            printTeams();
        }
        else
        {
            txtTeamNaam.text = "";
        }
    }

    public void createSession()
    {
        txtTeamNaam.gameObject.SetActive(false);
        btnAddTeam.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(true);
        recapTeams.gameObject.SetActive(true);
        btnStartSesstion.gameObject.SetActive(true);

        JSONNode N = new JSONObject();
        N["startTijd"] = DateTime.Now.ToString();

        for(int i =0; i<aantalTeams; i++)
        {
            N["teams"][i]["teamNaam"] = teamNamen[i];
            Debug.Log(i + teamNamen[i]);
        }
        Debug.Log(N.AsObject);
        api.ApiPost("Sessie",N);
    }

    public void printTeams()
    {
        Debug.Log("printTeams");
        txtTeamNaam.gameObject.SetActive(false);
        btnAddTeam.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(true);
        recapTeams.gameObject.SetActive(true);
        btnStartSesstion.gameObject.SetActive(true);
        string text = "Teamnamen: \n";

        foreach(string s in teamNamen)
        {
            Debug.Log(s);
            text += "-> " + s + "\n";
        }
        txtTeam.text = text;
        
    }
	
}
