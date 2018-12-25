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
    public Button btnPostSessie;
    public Button btnJoinSessie;

    public Image recapTeams;
    public Text txtTeam;
    public Text txtSessieCode;
    public Text txtSessieInfo;

    public int nextScene;
    public Slider sldLoader;
    public LevelLoader loader;

    TouchScreenKeyboard keyboard;


    // Use this for initialization
    void Start()
    {
        btnInitSessie.gameObject.SetActive(true);
        txtAantalGroepen.gameObject.SetActive(true);
        //txtAantalGroepen.keyboardType = TouchScreenKeyboardType.NumberPad;
        btnAddTeam.gameObject.SetActive(false);
        txtTeamNaam.gameObject.SetActive(false);
        recapTeams.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(false);
        btnPostSessie.gameObject.SetActive(false);
        txtSessieCode.gameObject.SetActive(false);
        txtSessieInfo.gameObject.SetActive(false);
        api = gameObject.AddComponent<APICaller>();
    }
    public void SessieInit()
    {
        //Debug.Log("sessieInit");
        aantalTeams=0;
        
        //Debug.Log(aantalTeams);
        if(int.TryParse(txtAantalGroepen.text, out aantalTeams))
        {
            if (aantalTeams > 0 && aantalTeams < 5)
            {
                //Debug.Log("hi");
                teamNamen = new List<string>();
                btnInitSessie.gameObject.SetActive(false);
                txtAantalGroepen.gameObject.SetActive(false);
                btnAddTeam.gameObject.SetActive(true);
                txtTeamNaam.gameObject.SetActive(true);
                teamCounter = 0;
                recapTeams.gameObject.SetActive(true);
                txtTeam.gameObject.SetActive(true);
                txtTeam.text = ("Geef de teamn aam waartoe jou team bij zit");
            }
            else
                txtAantalGroepen.text = "Aantal Groepen";
        }
        
    }

    public void AddTeam()
    {
        
        //Debug.Log("addTeams");
        string teamNaam = txtTeamNaam.text;
        txtTeamNaam.text = "team naam";
        txtAantalGroepen.text = txtTeamNaam.text;
        teamNamen.Add(teamNaam);
        teamCounter++;
        txtTeam.text = ("geef de naam van team:" + (teamCounter+1));
        //Debug.Log(teamCounter);
        if (teamCounter >= aantalTeams)
        {
            printTeams();
        }
        else
        {
            txtTeamNaam.text = "";
        }
    }

    public void printTeams()
    {
        //Debug.Log("printTeams");
        txtTeamNaam.gameObject.SetActive(false);
        btnAddTeam.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(true);
        recapTeams.gameObject.SetActive(true);
        btnPostSessie.gameObject.SetActive(true);
        string text = "Teamnamen: \n";

        foreach (string s in teamNamen)
        {
            //Debug.Log(s);
            text += "-> " + s + "\n";
        }
        txtTeam.text = text;

    }

    public void createSession()
    {
        txtTeamNaam.gameObject.SetActive(false);
        btnAddTeam.gameObject.SetActive(false);
        btnPostSessie.gameObject.SetActive(false);
        txtTeam.gameObject.SetActive(false);
        recapTeams.gameObject.SetActive(false);

        JSONNode N = new JSONObject();
        N["startTijd"] = DateTime.Now.ToString();

        for(int i =0; i<aantalTeams; i++)
        {
            N["teams"][i]["teamNaam"] = teamNamen[i];
            //Debug.Log(i + teamNamen[i]);
        }
        ////Debug.Log(N.AsObject);
        api.ApiPost("Sessie", N, CreateSessionCor);
        txtSessieCode.gameObject.SetActive(true);
        txtSessieInfo.gameObject.SetActive(true);
        btnJoinSessie.gameObject.SetActive(true);
        //StartCoroutine(CreateSessionCor());
        //Debug.Log(response);
    }
    void CreateSessionCor(string code)
    {
        Info.SessieCode = code;
        txtSessieCode.text = code;
        Debug.Log("done");
        Debug.Log(Info.SessieCode);
    }

    public void joinGame()
    {
        btnJoinSessie.gameObject.SetActive(false);
        string code = Info.SessieCode.ToString();
        Info.SessieCode = code;
        code = code.Trim('"');
        Debug.Log(Info.SessieCode + "code");
        string url = "Sessie/toList?code=" + code;
        Debug.Log(url);
        api.ApiGet(url,JoinGameCor);
        
    }
    void JoinGameCor(string json)
    {
        Debug.Log(json);
        var N = JSON.Parse(json);
        Info.TeamId = N["data"][0]["id"].AsInt;
        Info.TeamNaam = N["data"][0]["teamNaam"].Value;
        Debug.Log("joined: ");
        Debug.Log(Info.TeamId);
        Debug.Log(Info.TeamNaam);
        var url = "Team/" + Info.TeamId + "/AddSpeler?spelerID=" + Info.spelerId;
        api.ApiGet(url, NextLevel);
        
    }

    void NextLevel(string json)
    {
        loader.LoadLevel(nextScene);
    }

 
	
}
