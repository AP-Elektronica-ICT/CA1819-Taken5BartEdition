using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class GameCompleted : MonoBehaviour
{
    public int nextScene;
    public Slider sldLoader;
    public LevelLoader loader;
    private APICaller api;


    void Start()
    {
        api = gameObject.AddComponent<APICaller>();
    }


    public void NextGame()
    {
        //var N = JSON.Parse(api.ApiGet("http://localhost:1907/api/team/3/nextpuzzel"));
        //Debug.Log(N);
        //Debug.Log(Info.ActivePuzzel);
        //Info.ActivePuzzel = N["activePuzzel"].AsInt;
        //Debug.Log(Info.ActivePuzzel);

        //loader.LoadLevel(nextScene);

    }


}
