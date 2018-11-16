using SimpleJSON;
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
    public static void Update()
    {
        APICall api = new APICall();
        string url = "Speler/" + Info.spelerId.ToString() + "/Team";
        var N = JSON.Parse(api.ApiCall(url));
        TeamNaam = N["teamNaam"].Value;
        Diamanten = N["diamantenVerzameld"].AsInt;
        Score = N["score"].AsInt;
        TeamId = N["id"].AsInt;

        url = "Speler/" + Info.spelerId.ToString();
        N = JSON.Parse(api.ApiCall(url));
        Voornaam = N["voornaam"].Value;
    }
}
