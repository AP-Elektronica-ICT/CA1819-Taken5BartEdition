using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {
    private APICaller _api;
    private InfoUpdater updater;
    private double dist;
    public bool isDone { get; private set; }
                                       // Use this for initialization
    public void Setup()
    {
        _api = gameObject.AddComponent<APICaller>();
        updater = gameObject.AddComponent<InfoUpdater>();
        isDone = true;
    }

    public IEnumerator DistanceTo(Action<Double> doLast)
    {
        isDone = false;
        Debug.Log("updating distance");
        Debug.Log(updater);
        //StartCoroutine(updater.UpdateLocatie(_api, getDone));
        yield return new WaitUntil(() => !isDone);
        var result = DistanceToDummy();
        doLast(result);
    }
    public IEnumerator DistanceTo()
    {
        isDone = false;
        Debug.Log("updating distance");
        Debug.Log(updater);
        StartCoroutine(updater.UpdateLocatie(_api, getDone));
        yield return new WaitUntil(() => !isDone);
        var result = DistanceToDummy();
    }
    private void getDone()
    {
        isDone = true;
    }
    
    private double DistanceToGPS()
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
        return dist;
    }
    private double DistanceToDummy()
    {
        double latGame = Info.Latitude;
        double lonGame = Info.Longitude;
        //Debug.Log("Lat:"+latGame);
        //Debug.Log("Long:" + lonGame);
        dist = 30;
        return dist;
    }
}
