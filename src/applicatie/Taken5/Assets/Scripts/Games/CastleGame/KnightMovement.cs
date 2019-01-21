using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class KnightMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public Text scoreText;

    float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    GameObject playerObject;

    double beginPositie = 0;
    double eindPositie = 150;

    //static string ScoreURL = "http://localhost:1907/api/steenscores";

    APICaller api;
    string url = "/steenscores";

    // Use this for initialization
    void Start () {
        playerObject = GameObject.Find("Knight");
        api = gameObject.AddComponent<APICaller>();
    }
	
	// Update is called once per frame
	void Update () {
        // change score on screen
        scoreText.text = CalculateScore().ToString() + "/10";

        // check if player is to low and dies
        if (playerObject.transform.position.y < 0)
        {
            StartCoroutine(Dies());
        }

        // check if player reached end of the game
        if (playerObject.transform.position.x > eindPositie)
        {
            StartCoroutine(Winner());
        }

        Debug.Log("current score is " + CalculateScore());

        // check if screen is touched to jump
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            animator.SetBool("IsJumping", true);
            jump = true;
        }
    }

    // stop jump animation on landing
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    // update function dat runs undependant from frames per second, on fixed time
    void FixedUpdate()
    {
        controller.Move(runSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    int CalculateScore()
    {
        int score = Convert.ToInt32((playerObject.transform.position.x / (eindPositie - beginPositie)) * 10);
        return score;
    }

    IEnumerator Winner()
    {
        animator.SetBool("IsWinning", true);
        runSpeed = 0f;
        yield return new WaitForSeconds(5);
        PostScore();
        Application.LoadLevel("SteenGameStart");
    }

    IEnumerator Dies()
    {
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.7f);
        PostScore();
        Application.LoadLevel("SteenGameStart");
    }

    void PostScore()
    {
        JSONNode N = new JSONObject();

        N["DeviceID"] = SystemInfo.deviceUniqueIdentifier;
        N["score"] = CalculateScore();

        Debug.Log("score " + CalculateScore());

        //StartCoroutine(WWWPost(N));

        api.ApiPost(url, N);
    }



    /*public static IEnumerator WWWPost(JSONNode N)
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

    }*/
}
