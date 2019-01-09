using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForOtherPlayers : MonoBehaviour {


    public Button button;
    public Slider slider;
    public GameObject loadingscreen;

    APICaller _api;
    LevelLoader levelLoader;
	// Use this for initialization
	void Start ()
    {
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        levelLoader.slider = slider;
        levelLoader.loadingscreen = loadingscreen;
        button.onClick.AddListener(onclick);
    }

    // Update is called once per frame
    void Update ()
    {
    
        //levelLoader.ChangeGameMode(Info.TeamId, _api);

    }

    void onclick()
    {
        Debug.Log("onclick");
        levelLoader.DevChangeGameMode(Info.TeamId, _api);
    }
}
