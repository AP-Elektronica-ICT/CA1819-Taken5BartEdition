using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRegisterd : MonoBehaviour
{
    string url;
    public Button button1;
    public Button button2;
    public Slider slider;
    public GameObject loadingscreen;
    LevelLoader levelLoader;

    public Text voornaam;
    public Text achternaam;
    string textvoornaam = "";
    string textachternaam = "";
    int nextlevel = 1;
    bool registerd = false;
    bool startcheck = true;
    APICaller api;

    // Use this for initialization
    void Start()
    {
        url = "speler/register/" + SystemInfo.deviceUniqueIdentifier.ToString();
        api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        levelLoader.slider = slider;
        levelLoader.loadingscreen = loadingscreen;
        button2.onClick.AddListener(OnClick);

        Debug.Log(url);
        StartCoroutine(api.Get(url, CheckIfRegisterd));
        
    }
    
    public void CheckIfRegisterd(string json)
    {
        Debug.Log("Checking...");
        if (json != "-1" && json !="")
        {
            var N = JSON.Parse(json);
            Debug.Log(N);
            textvoornaam = N["voornaam"].Value.ToString();
            textachternaam = N["achternaam"].Value.ToString();

            Info.Voornaam = textvoornaam;
            Info.SpelerNaam = textvoornaam + " " + textachternaam;
            Info.spelerId = N["id"];

            Debug.Log("InfoTypes:");
            Debug.Log("voornaam: " + Info.Voornaam);
            Debug.Log("spelernaam: " + Info.SpelerNaam);
            Debug.Log("spelerid: " + Info.spelerId);

            if (startcheck)
            { 
                StartCoroutine(api.Get("speler/" + Info.spelerId + "/team",CheckInTeam));
                Debug.Log("startcheck");
                startcheck = false;
            }
            button1.interactable = false;
            button2.interactable = true;
            updatetext();
            registerd = true;
            Debug.Log(nextlevel);
            


        }
    }
    void CheckInTeam(string json)
    {
        Debug.Log("checkinteam");
        var N = JSON.Parse(json);
        Debug.Log(json);
        if (N != "" && N!="-1")
        {
            Debug.Log("in if");
            StartCoroutine(api.Get("speler/" + Info.spelerId + "/sessie", CheckInSessie));
            Info.TeamNaam = N["teamnaam"].Value.ToString();
            Info.TeamId = N["id"];
            Info.ActivePuzzel = N["activepuzzel"];
           
        }
    }
    void CheckInSessie(string json)
    {
        Debug.Log("checkinsession");
        Debug.Log(json);
        var N = JSON.Parse(json);
        if (N != "" && N != "-1")
        {
            Info.SessieId = N["id"];
            nextlevel = 5;
            Debug.Log(Info.SessieId);
        }
    }

    public void OnClick()
    {
        Debug.Log("check");
        StartCoroutine(api.Get(url, CheckIfRegisterd));
        if (registerd)
        {
            Debug.Log("check");
            levelLoader.LoadLevel(nextlevel);

        }
    }

    void updatetext()
    {
        voornaam.text = textvoornaam;
        achternaam.text = textachternaam;
    }
}
