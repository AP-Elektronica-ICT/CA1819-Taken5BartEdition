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
		double distance = Distance.DistanceTo(51.064741, 5.300315);

        if (distance <= 20)
        {
            switch (levelId)
            {
                case 0:
                    Application.LoadLevel("BraboGame");
                    break;
            }
        }
	}
}
