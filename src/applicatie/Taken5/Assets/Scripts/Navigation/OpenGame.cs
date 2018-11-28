using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGame : MonoBehaviour {
    int levelId = 0;
    Distance _distance;

	// Use this for initialization
	void Start () {
        _distance = gameObject.AddComponent<Distance>();
        _distance.SetAPI(gameObject.AddComponent<APICaller>());
        Info.Diamanten = 1; //TD fix diamant id begint bij 0
	}
	
	// Update is called once per frame
	void Update () {
        levelId = Info.Diamanten;
        if (_distance.isDone)
        {
            _distance.DistanceTo();
        }
        double distance = _distance.dist;
        //Debug.Log(distance);

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
}
