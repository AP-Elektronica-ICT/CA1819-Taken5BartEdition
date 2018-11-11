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
        distance.text = Math.Round(Distance.DistanceTo(51.229781, 4.416107)).ToString() + " m";
    }
}
