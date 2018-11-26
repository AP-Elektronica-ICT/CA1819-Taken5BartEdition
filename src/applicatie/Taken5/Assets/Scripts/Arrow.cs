using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SimpleJSON;

public class Arrow : MonoBehaviour {

    public Text distance;
    int test = 0;

    // Use this for initialization
    void Start() {
        distance.text = "0 m";
    }

    // Update is called once per frame
    void Update() {
        //distance.text = Math.Round(Distance.DistanceTo()).ToString() + " m";

        distance.text = "hey 1";

        Info.Update();
        distance.text = Info.Longitude.ToString();

        


    }

    [Serializable]
    private class Positie
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
