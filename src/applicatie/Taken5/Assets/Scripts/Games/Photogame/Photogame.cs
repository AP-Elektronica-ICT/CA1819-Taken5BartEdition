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

    static string ScoreURL = "http://localhost:1907/api/photogamescores";

    // Use this for initialization
    void Start () {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);

        Button btn = seePictureButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        foto.SetActive(false);
        deathText.SetActive(false);
        winText.SetActive(false);
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
        PostScore(0);
        Application.LoadLevel("PhotoGame");
    }

    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(5f);
        PostScore(10);
        Application.LoadLevel("PhotoGame");
    }

    void PostScore(int score)
    {
        JSONNode N = new JSONObject();

        N["DeviceID"] = SystemInfo.deviceUniqueIdentifier;
        N["score"] =score;

        Debug.Log("score " + score);

        StartCoroutine(WWWPost(N));
    }

    public static IEnumerator WWWPost(JSONNode N)
    {
        {
            var req = new UnityWebRequest(ScoreURL, "POST");
            byte[] data = Encoding.UTF8.GetBytes(N.ToString());

            req.uploadHandler = new UploadHandlerRaw(data);
            req.uploadHandler.contentType = "application/json";
            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("accept", "application/json");

            yield return req.SendWebRequest();

            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(data);
            }
        }

    }
}
