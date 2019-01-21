using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Vuforia;

public class Vlaeykens : MonoBehaviour, ITrackableEventHandler {

    public TrackableBehaviour mTrackableBehaviour;
    public Button seeRiddleButton;
    public GameObject riddle;
    public Text buttonText;
    public Text scoreText;
    public Text timerText;
    public GameObject deathText;

    private float timePast = 0.0f;
    private float timeLimit = 300.0f; //tijdlimiet in seconden
    private float timeLeft = 0.1f;
    private int score = 10;
    private int finalScore = 0;

    APICaller api;
    string url = "/vlaeykensscores";

    // Use this for initialization
    void Start () {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);

        Button btn = seeRiddleButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        riddle.SetActive(true);
        deathText.SetActive(false);

        api = gameObject.AddComponent<APICaller>();
    }
	
	// Update is called once per frame
	void Update () {
        timePast += Time.deltaTime;
        timeLeft = timeLimit - timePast;
        if (timeLeft < 0)
        {
            StartCoroutine(Death());
        }
        else
        {
            UpdateScore();
            UpdateTimer();
            scoreText.text = score.ToString() + "/10";
        }
	}

    void TaskOnClick()
    {
        if (riddle.activeSelf == false)
        {
            riddle.SetActive(true);
            buttonText.text = "Hide Riddle";
        }
        else
        {
            riddle.SetActive(false);
            buttonText.text = "Show Riddle";
        }

    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (timeLeft > 0)
            {
                finalScore = score;
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(5f);
        PostScore(finalScore);
        Application.LoadLevel("VlaeykensGame");
    }

    IEnumerator Death()
    {
        riddle.SetActive(false);
        deathText.SetActive(true);
        yield return new WaitForSeconds(5f);
        PostScore(0);
        Application.LoadLevel("VlaeykensGame");

    }

    void UpdateScore()
    {
        score = Convert.ToInt32(10-((timePast / timeLimit)*10));
    }

    void UpdateTimer()
    {
        float secf = timeLeft % 60;
        double sec = Math.Floor((double)secf);
        float minf = timeLeft / 60;
        double min = Math.Floor((double)minf);

        if (sec > 9)
        {
            timerText.text = min.ToString() + ":" + sec.ToString();
        }
        else
        {
            timerText.text = min.ToString() + ":0" + sec.ToString();
        }
    }

    void PostScore(int score)
    {
        JSONNode N = new JSONObject();

        N["DeviceID"] = SystemInfo.deviceUniqueIdentifier;
        N["score"] = score;

        Debug.Log("score " + score);

        api.ApiPost(url, N);
    }
}
