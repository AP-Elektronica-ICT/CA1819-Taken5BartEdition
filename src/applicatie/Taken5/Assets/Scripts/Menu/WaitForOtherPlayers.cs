using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForOtherPlayers : MonoBehaviour {


    public Button button;
    public Slider slider;
    public GameObject loadingscreen;
    bool docall = true;
    APICaller _api;
    LevelLoader levelLoader;
	// Use this for initialization
	void Start ()
    {
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        levelLoader.slider = slider;
        levelLoader.loadingscreen = loadingscreen;
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (docall)
        {
            StartCoroutine(changer());

        }
    }
    IEnumerator changer()
    {
        docall = false;
        yield return new WaitForSeconds(10); //Count is the amount of time in seconds that you want to wait..
        Debug.Log("changer");

        levelLoader.ChangeGameMode(_api);

        //And here goes your method of resetting the game...
        docall = true;
        yield return null;
    }

}
