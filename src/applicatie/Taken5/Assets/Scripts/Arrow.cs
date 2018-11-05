using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Text distance;
    int test = 0;

    // Use this for initialization
    void Start () {
        distance.text = "0 m";
    }
	
	// Update is called once per frame
	void Update () {
        distance.text = Math.Round(DistanceTo(GPS.Instance.latitude, GPS.Instance.longitude, 51.063821, 5.297818)).ToString() + " m";
    }

    public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
    {
        double rlat1 = Math.PI * lat1 / 180;
        double rlat2 = Math.PI * lat2 / 180;
        double theta = lon1 - lon2;
        double rtheta = Math.PI * theta / 180;
        double dist =
            Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
            Math.Cos(rlat2) * Math.Cos(rtheta);
        dist = Math.Acos(dist);
        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;
        dist = dist * 1.609344 * 1000;

        return dist;
    }
}
