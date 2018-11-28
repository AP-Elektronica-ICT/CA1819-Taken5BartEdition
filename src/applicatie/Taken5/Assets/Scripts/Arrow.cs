using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SimpleJSON;

public class Arrow : MonoBehaviour {

    public Text distance;
    int test = 0;
    Distance _distance;

    // Use this for initialization
    void Start() {
        _distance = gameObject.AddComponent<Distance>();
        distance.text = "0 m";
    }

    // Update is called once per frame
    void Update() {
        //distance.text = Math.Round(Distance.DistanceTo()).ToString() + " m";
        if (_distance.isDone)
        {
            _distance.DistanceTo();
        }
        double dist = _distance.dist;
        distance.text = dist.ToString()+" m";

        //distance.text = Info.Longitude.ToString();

        


    }
}
