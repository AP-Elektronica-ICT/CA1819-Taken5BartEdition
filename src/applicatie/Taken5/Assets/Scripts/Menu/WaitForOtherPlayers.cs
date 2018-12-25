using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForOtherPlayers : MonoBehaviour {


    public Button button;

    APICaller _api;
    LevelLoader levelLoader;
	// Use this for initialization
	void Start ()
    {
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();

    }

    // Update is called once per frame
    void Update ()
    {
        levelLoader.ChangeGameMode(Info.TeamId, _api);
	}
}
