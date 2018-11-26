using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGame : MonoBehaviour {
    int levelId = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		double distance = Distance.DistanceTo();

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
