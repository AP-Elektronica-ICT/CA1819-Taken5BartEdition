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

    string teamScoreUrl = "vlaeykensscores/" + Info.TeamId;
    int totalScore = 0;
    int aantalSpelers = 0;
    double gemiddeldeScore = 0;
    LevelLoader levelLoader;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);

        Button btn = seeRiddleButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        riddle.SetActive(true);
        deathText.SetActive(false);

        api = gameObject.AddComponent<APICaller>();

        levelLoader = gameObject.AddComponent<LevelLoader>();
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
        api.ApiGet(teamScoreUrl, (result) => getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "vleaykensgang", gemiddeldeScore);
    }

    IEnumerator Death()
    {
        riddle.SetActive(false);
        deathText.SetActive(true);
        yield return new WaitForSeconds(5f);
        finalScore = 0;
        PostScore(finalScore);
        api.ApiGet(teamScoreUrl, (result) => getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "vleaykensgang", gemiddeldeScore);

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

        N["TeamID"] = Info.TeamId;
        N["score"] = score;

        Debug.Log("score " + score);

        api.ApiPost(url, N);
    }

    public void getScores(string json)
    {
        Debug.Log("getscores:");
        Debug.Log(json);
        var N = JSON.Parse(json);
        totalScore = 0;
        aantalSpelers = 0;
        foreach (JSONNode score in N)
        {
            totalScore = totalScore + (Int32.Parse(score["score"].Value));
            aantalSpelers++;
        }
        totalScore = totalScore + finalScore;
        aantalSpelers = aantalSpelers++;
        gemiddeldeScore = totalScore / aantalSpelers;

        Debug.Log("totale score: " + totalScore);
        Debug.Log("totaal aantal spelers: " + aantalSpelers);
        Debug.Log("gemiddelde score: " + gemiddeldeScore);
    }
}
