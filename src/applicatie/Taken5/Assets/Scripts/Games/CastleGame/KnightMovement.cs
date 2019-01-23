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
    string url = "steenscores";

    //DEZE TOEVOEGEN
    string teamScoreUrl = "steenscores/" + Info.TeamId;
    int totalScore = 0;
    int aantalSpelers = 0;
    double gemiddeldeScore = 0;
    LevelLoader levelLoader;

    // Use this for initialization
    void Start () {
        playerObject = GameObject.Find("Knight");
        api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
    }
	
	// Update is called once per frame
	void Update () {
        // change score on screen
        scoreText.text = CalculateScore().ToString() + "/10";

        // check if player is to low and dies
        if (playerObject.transform.position.y < 0)
        {
            StartCoroutine(Dies());
            StartCoroutine(api.Get2(teamScoreUrl, (result) => getScores(result)));
        }

        // check if player reached end of the game
        if (playerObject.transform.position.x > eindPositie)
        {
            StartCoroutine(Winner());
            StartCoroutine(api.Get2(teamScoreUrl, (result) => getScores(result)));
        }

        Debug.Log("current score is " + CalculateScore());
        try { 
        // check if screen is touched to jump
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
            
                animator.SetBool("IsJumping", true);
                jump = true;
            }
        }
        catch(ArgumentException e)
        {
            Debug.Log(e);
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

        //Deze toevoegen
        api.ApiGet(teamScoreUrl, (result)=> getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "hetSteen", gemiddeldeScore);
    }

    IEnumerator Dies()
    {
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.7f);
        PostScore();

        //Deze toevoegen
        api.ApiGet(teamScoreUrl, (result) => getScores(result));
        levelLoader.ChangeGameModeEndOfGame(api, "hetSteen", gemiddeldeScore);
    }

    void PostScore()
    {
        
        JSONNode N = new JSONObject();

        N["TeamID"] = Info.TeamId;
        N["Score"] = CalculateScore();

        Debug.Log("score " + CalculateScore());

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
        totalScore = totalScore + CalculateScore();
        aantalSpelers = aantalSpelers++;
        gemiddeldeScore = totalScore / aantalSpelers;

        Debug.Log("totale score: " + totalScore);
        Debug.Log("totaal aantal spelers: " + aantalSpelers);
        Debug.Log("gemiddelde score: " + gemiddeldeScore);
    }


}
