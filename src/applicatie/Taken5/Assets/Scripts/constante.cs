using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info 
{
    public static int spelerId = 2;
    public static string Voornaam { get; set; }
    public static int TeamId { get; set; }
    public static string SpelerNaam { get; set; }
    public static string TeamNaam { get; set; }
    public static int Diamanten { get; set; }
    public static int Score { get; set; }
    public static string SessieCode { get; set; }

    public static InfoUpdater updater;
    
}

public class InfoUpdater
{
    APICaller _api;
    JSONNode N;
    string result;
    bool isDone;

    public InfoUpdater(APICaller api)
    {
        _api = api;
    }
    public IEnumerator UpdateInfo(Action doAfter)
    {
        isDone = false;
        string url = "Speler/" + Info.spelerId.ToString() + "/Team";
        JSON.Parse(_api.ApiGet(url, LoadTeamData));
        yield return new WaitUntil(() => isDone);
        doAfter();
    }

    void LoadTeamData()
    {
        var N = JSON.Parse(_api.json);
        Info.TeamNaam = N["teamNaam"].Value;
        Info.Diamanten = N["diamantenVerzameld"].AsInt;
        Info.Score = N["score"].AsInt;
        Info.TeamId = N["id"].AsInt;

        var url = "Speler/" + Info.spelerId.ToString();
        _api.ApiGet(url, LoadSpelerData);

        
    }
    void LoadSpelerData()
    {
        var N = JSON.Parse(_api.json);
        Info.Voornaam = N["voornaam"].Value;
        isDone = true;
    }
}
