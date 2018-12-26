using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info
{
    public static int spelerId { get; set; }
    public static string Voornaam { get; set; }
    public static int TeamId { get; set; }
    public static int ActivePuzzel { get; set; }
    public static string SpelerNaam { get; set; }
    public static string TeamNaam { get; set; }
    public static int Diamanten { get; set; }
    public static int Score { get; set; }
    public static string SessieCode { get; set; }
    public static int SessieId { get; set; }
    public static double Longitude { get; set; }
    public static double Latitude { get; set; }
}

public class InfoUpdater : MonoBehaviour
{
    private bool isDone;
    public IEnumerator UpdateInfo(APICaller _api, Action doLast)
    {
        isDone = false;
        string url = "Speler/" + Info.spelerId.ToString() + "/Team";
        StartCoroutine(_api.Get(url, (result) => { //lamba functie zijn ook een opties om dit op te lossen
            GetSpeler(result);

            }));
        
        url = "Speler/" + Info.spelerId.ToString();
        StartCoroutine(_api.Get(url, GetSpeler));
        yield return new WaitUntil(() => !isDone);
        doLast();
    }
    
    private void GetTeam(string json)
    {

        var N = JSON.Parse(json);
        Info.TeamNaam = N["teamNaam"].Value;
        Info.Diamanten = N["diamantenVerzameld"].AsInt;
        Info.Score = N["score"].AsInt;
        Info.TeamId = N["id"].AsInt;
    }

    private void GetSpeler(string json)
    {
        var N = JSON.Parse(json);
        Info.Voornaam = N["voornaam"].Value;
        isDone = true;
    }

    public IEnumerator UpdateLocatie(APICaller _api, Action doLast)
    {
        isDone = false;
        var url = "puzzel/" + (Info.Diamanten) + "/location";

        StartCoroutine(_api.Get(url, Locatie));
        
        yield return new WaitUntil(() => !isDone);
        doLast();
    }

    private void Locatie(string json)
    {
        var N = JSON.Parse(json);
        Info.Longitude = N["longitude"].AsDouble;
        Info.Latitude = N["latitude"].AsDouble;
        isDone = true;
    }
}
