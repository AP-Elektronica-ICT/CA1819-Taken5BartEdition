using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static double DistanceTo(double lat, double lon)
    {
        double rlat1 = Math.PI * GPS.Instance.latitude / 180;
        double rlat2 = Math.PI * lat / 180;

        double theta = GPS.Instance.longitude - lon;
        double rtheta = Math.PI * theta / 180;

        double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);

        dist = Math.Acos(dist);
        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;
        dist = dist * 1.609344 * 1000;

        return dist;
    }
}
