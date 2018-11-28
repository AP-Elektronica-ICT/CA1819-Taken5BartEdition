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
    public static double Longitude { get; set; }
    public static double Latitude { get; set; } 

    public static InfoUpdater updater;
    
}

public class InfoUpdater
{
    APICaller _api;
    bool isDone;

    public InfoUpdater(APICaller api)
    {
        _api = api;
    }
    public IEnumerator UpdateInfo(Action doAfter)
    {
        isDone = false;
        string url = "Speler/" + Info.spelerId.ToString() + "/Team";
        _api.ApiGet(url, LoadTeamData);
        yield return new WaitUntil(() => isDone);
        doAfter();
    }
    public IEnumerator UpdateLocatie(Action doAfter)
    {
        isDone = false;
        var url = "puzzel/" + Info.Diamanten + "/location";
        _api.ApiGet(url, LoadPuzzelLocatie);
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

       
        /*
        url = "puzzel/" + "1" + "/location";
        N = JSON.Parse(_api.ApiGet(url, LoadSpelerData));
        */
    }
    void LoadSpelerData()
    {
        var N = JSON.Parse(_api.json);
        Info.Voornaam = N["voornaam"].Value;

        var url = "puzzel/" + Info.Diamanten + "/location";
        N = JSON.Parse(_api.ApiGet(url, LoadPuzzelLocatie));
        
    }
    void LoadPuzzelLocatie()
    {
        var N = JSON.Parse(_api.json);
        Info.Longitude = N["longitude"].AsDouble;
        Info.Latitude = N["latitude"].AsDouble;
        isDone = true;
    }
}
