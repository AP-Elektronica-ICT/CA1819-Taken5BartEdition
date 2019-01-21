using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGame : MonoBehaviour {
    int activepuzzel = 0;
    public Dropdown dropdown;
    public Button btn_nextlevel;

    Distance _distance;
    double distance;
    LevelLoader loader;

    // Use this for initialization
    void Start ()
    {
        _distance = gameObject.AddComponent<Distance>();
        _distance.Setup();
        loader = gameObject.AddComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update");
        // Debug.Log(dropdown.value);
        if (Info.ActivePuzzel == 9)
        {
            loader.LoadLevel(1);
               
        }
        activepuzzel = Info.ActivePuzzel;
        distance = _distance.DistanceToGPS();

        if (distance <= 20 ||dropdown.value > 0)
        {
          //  Debug.Log("button available ");
            btn_nextlevel.interactable = true;
        }
        else
        {
         //   Debug.Log("button disable ");

            btn_nextlevel.interactable = false;
        }
    }
}

