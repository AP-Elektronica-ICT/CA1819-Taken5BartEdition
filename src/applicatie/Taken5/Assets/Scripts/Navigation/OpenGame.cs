using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGame : MonoBehaviour {
    int activepuzzel = 0;
    Distance _distance;
    double distance;
    Button btn_nextlevel;


    // Use this for initialization
    void Start ()
    {
        _distance.Setup();
     
    }

    // Update is called once per frame
    void Update()
    {
        activepuzzel = Info.ActivePuzzel;
        if (_distance.isDone)
        {
            _distance.DistanceTo();
        }
        //  double distance = _distance.DistanceTo();
        Debug.Log(distance);

        if (distance <= 20)
        {

            btn_nextlevel.interactable = true;

       
        }
        else
        {
            btn_nextlevel.interactable = false;
        }
    }
}

