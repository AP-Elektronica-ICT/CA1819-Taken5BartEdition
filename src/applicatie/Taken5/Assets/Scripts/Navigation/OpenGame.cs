using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGame : MonoBehaviour {
    int levelId = 0;
    Distance _distance;
    double distance;
	// Use this for initialization
	void Start () {
        _distance = gameObject.AddComponent<Distance>();
        _distance.Setup();
        Info.Diamanten = 1; //TD fix diamant id begint bij 0
        distance = 10000;
    }
	
	// Update is called once per frame
	void Update () {
        levelId = Info.Diamanten;
        
        if (_distance.isDone)
        {
            StartCoroutine(_distance.DistanceTo(updateDistance));
        }
        

        if (distance <= 20)
        {
            switch (levelId)
            {
                //brabogame starten
                case 0:
                    Application.LoadLevel("BraboGame");
                    break;
                
                case 1:
                    break;
                
                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;
            }
        }
	}
    private void updateDistance(Double dist)
    {
       distance = dist;
    }
}
