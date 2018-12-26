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

    APICaller api;

    // Use this for initialization
    void Start()
    {
        url = "speler/register/" + SystemInfo.deviceUniqueIdentifier.ToString();
        api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        levelLoader.slider = slider;
        levelLoader.loadingscreen = loadingscreen;
        button2.onClick.AddListener(onclick);


        Debug.Log(url);
        StartCoroutine(api.Get(url, CheckIfRegisterd));
        
    }
    
    void CheckIfRegisterd(string json)
    {
        Debug.Log("function");

        var N = JSON.Parse(json);
        Debug.Log(N);

        if (N != "-1")
        {
            

            textvoornaam = N["voornaam"].Value.ToString();
            textachternaam = N["achternaam"].Value.ToString();

            Info.Voornaam = textvoornaam;
            Info.SpelerNaam = textvoornaam + " " + textachternaam;
            Info.spelerId = N["id"];


            StartCoroutine(api.Get("speler/" + Info.spelerId + "team",CheckInTeam));
            button1.interactable = false;
            button2.interactable = true;
            updatetext();


            


        }
    }
    void CheckInTeam(string json)
    {
        var N = JSON.Parse(json);
        if (N != "")
        {
            StartCoroutine(api.Get("speler/" + Info.spelerId + "sessie", CheckInSessie));
            Info.TeamNaam = N["teamnaam"].Value.ToString();
            Info.TeamId = N["id"];
            Info.ActivePuzzel = N["activepuzzel"];
           
        }
    }
    void CheckInSessie(string json)
    {
        var N = JSON.Parse(json);
        if (N != "")
        {
            Info.SessieId = N["id"];
            nextlevel = 5;
        }
    }

    void onclick()
    {
        levelLoader.LoadLevel(nextlevel);
    }

    void updatetext()
    {
        voornaam.text = textvoornaam;
        achternaam.text = textachternaam;
    }
}
