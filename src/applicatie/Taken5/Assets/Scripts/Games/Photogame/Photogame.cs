using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Vuforia;

public class Photogame : MonoBehaviour, ITrackableEventHandler
{
    public TrackableBehaviour mTrackableBehaviour;
    public Button seePictureButton;
    public Text buttonText;
    public GameObject foto;
    public Text timer;
    public GameObject deathText;
    public GameObject winText;


    private float timePast = 0.0f;
    private float timeLimit = 300.0f; //tijdlimiet in seconden
    private float timeLeft = 0.1f;

    APICaller api;
    string url = "/photogamescores";

    string teamScoreUrl = "photogamescores/" + Info.TeamId;
    int totalScore = 0;
    int aantalSpelers = 0;
    double gemiddeldeScore = 0;
    LevelLoader levelLoader;
    int endScore = 0;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);

        Button btn = seePictureButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        foto.SetActive(false);
        deathText.SetActive(false);
        winText.SetActive(false);

        api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (timeLeft > 0)
            {
                StartCoroutine(Win());
            }
        }
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
            UpdateClock();
        }
	}

    void TaskOnClick()
    {
        //if(buttonText.text == "See Image")
        if(foto.activeSelf == false)
        {
            buttonText.text = "Hide Image";
            foto.SetActive(true);
        }
        else
        {
            buttonText.text = "See Image";
            foto.SetActive(false);
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

    IEnumerator Death()
    {
        deathText.SetActive(true);
        seePictureButton.interactable = false;
        yield return new WaitForSeconds(5f);
        endScore = 0;
        PostScore(endScore);
        api.ApiGet(teamScoreUrl, (result) => getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "mas", gemiddeldeScore);
    }

    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(5f);
        endScore = 10;
        PostScore(endScore);
        api.ApiGet(teamScoreUrl, (result) => getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "mas", gemiddeldeScore);
    }

    void PostScore(int score)
    {
        JSONNode N = new JSONObject();

        N["TeamID"] = Info.TeamId;
        N["score"] =score;

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
        totalScore = totalScore + endScore;
        aantalSpelers = aantalSpelers++;
        gemiddeldeScore = totalScore / aantalSpelers;

        Debug.Log("totale score: " + totalScore);
        Debug.Log("totaal aantal spelers: " + aantalSpelers);
        Debug.Log("gemiddelde score: " + gemiddeldeScore);
    }
}
