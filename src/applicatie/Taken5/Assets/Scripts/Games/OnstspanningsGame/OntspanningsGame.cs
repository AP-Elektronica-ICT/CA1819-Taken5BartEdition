using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OntspanningsGame : MonoBehaviour {

    public Text timer;

    private float timePast = 0.0f;
    private float timeLimit = 901.0f; //tijdlimiet in seconden
    private float timeLeft = 0.1f;
    // Use this for initialization
    APICaller api;
    LevelLoader levelLoader;
    void Start () {
        UpdateClock();
        api = api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
    }
	
	// Update is called once per frame
	void Update () {
        timePast += Time.deltaTime;
        timeLeft = timeLimit - timePast;
        if (timeLeft < 0)
        {
            levelLoader.ChangeGameModeEndOfGame(api, "stadswaag", 10);
        }
        else
        {
            UpdateClock();
        }
	}

    void UpdateClock()
    {
        float secf = timeLeft % 60;
        double sec = Math.Floor((double)secf);
        float minf = timeLeft / 60;
        double min = Math.Floor((double)minf);

        if (sec > 9)
        {
            timer.text = min.ToString() + ":" + sec.ToString();
        }
        else
        {
            timer.text = min.ToString() + ":0" + sec.ToString();
        }
    }
}
