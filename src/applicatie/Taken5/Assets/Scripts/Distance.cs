using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {
    private APICaller _api;
    public double dist;
    public bool isDone;
	// Use this for initialization
	public void SetAPI(APICaller api)
    {
        _api = api;
        Info.updater = new InfoUpdater(api);
        isDone = true;
    }

    public void DistanceTo()
    {
        Debug.Log("updating");
        isDone = false;
        dist = 10000;
        StartCoroutine(Info.updater.UpdateLocatie(DistanceToCor));
    }
    
    void DistanceToCor()
    {
        double latGame = Info.Latitude;
        double lonGame = Info.Longitude;

        double rlat1 = Math.PI * GPS.Instance.latitude / 180;
        double rlat2 = Math.PI * latGame / 180;

        double theta = GPS.Instance.longitude - lonGame;
        double rtheta = Math.PI * theta / 180;

        double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);

        dist = Math.Acos(dist);
        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;
        dist = dist * 1.609344 * 1000;
        isDone = true;
    }
    void DistanceToCorDummy()
    {
        double latGame = Info.Latitude;
        double lonGame = Info.Longitude;
        Debug.Log("Lat:"+latGame);
        Debug.Log("Long:" + lonGame);
        dist = 25;
        isDone = true;
    }
}
