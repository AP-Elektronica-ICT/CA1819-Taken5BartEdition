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
    public Text voornaam;
    public Text achternaam;
    string textvoornaam = "";
    string textachternaam = "";

    APICaller api;

    // Use this for initialization
    void Start()
    {
        url = "speler/register/" + SystemInfo.deviceUniqueIdentifier.ToString();
        api = gameObject.AddComponent<APICaller>();
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
            button1.interactable = false;
            button2.interactable = true;
            updatetext();
        }
    }
    
   
    void updatetext()
    {
        voornaam.text = textvoornaam;
        achternaam.text = textachternaam;
    }
}
