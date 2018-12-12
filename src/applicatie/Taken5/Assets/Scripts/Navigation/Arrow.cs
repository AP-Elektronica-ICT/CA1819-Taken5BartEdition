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
        _distance.Setup();
        distance.text = "0 m";
    }

    // Update is called once per frame
    void Update() {
        //distance.text = Math.Round(Distance.DistanceTo()).ToString() + " m";
        if (_distance.isDone)
        {
            StartCoroutine(_distance.DistanceTo(updateDist));
        }
    }
    void updateDist(double dist)
    {
        distance.text = dist.ToString() + " m";
    }
}
