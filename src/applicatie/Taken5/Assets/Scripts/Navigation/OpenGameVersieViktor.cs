using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGameVersieViktor : MonoBehaviour {
    int levelId = 0;
    Distance _distance;
<<<<<<< HEAD
    double distance;
=======
>>>>>>> master

    // Use this for initialization
    void Start()
    {
        _distance = gameObject.AddComponent<Distance>();
<<<<<<< HEAD
        _distance.Setup();
=======
        _distance.SetAPI(gameObject.AddComponent<APICaller>());
>>>>>>> master
        Info.Diamanten = 0; //TD fix diamant id begint bij 0
    }

    // Update is called once per frame
    void Update()
    {
        levelId = Info.Diamanten;
        if (_distance.isDone)
        {
            _distance.DistanceTo();
        }
<<<<<<< HEAD
      //  double distance = _distance.DistanceTo();
=======
        double distance = _distance.dist;
>>>>>>> master
        //Debug.Log(distance);

        if (distance <= 20)
        {
            switch (levelId)
            {
                //brabogame starten
                case 0:
                    Application.LoadLevel("VlaamseKaai");
                    break;

                case 1:
                    Application.LoadLevel("Quiz"); //stadsfeestzaal

                    break;

                case 2:
                    Application.LoadLevel("Kathedraal");

                    break;

                case 3:
                    Application.LoadLevel("vlaeykensgang");

                    break;

                case 4:
                    Application.LoadLevel("GroteMarkt");

                    break;

                case 5:
                    Application.LoadLevel("HetSteen");

                    break;

                case 6:
                    Application.LoadLevel("Mas");

                    break;

                case 7:
                    Application.LoadLevel("Havenhuis");

                    break;
            }
        }
    }
}
