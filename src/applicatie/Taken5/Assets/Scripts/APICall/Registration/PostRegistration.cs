using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostRegistration : MonoBehaviour
{

    static string url = "speler";
    public Text Voornaam;
    public Text Achternaam;
    string voornaam;
    string achternaam;
    public   Button button;
    public APICaller api;
    void Update()
    {
        api = gameObject.AddComponent<APICaller>();

        voornaam = Voornaam.text;
        achternaam = Achternaam.text;
    }
  
    public void OnClick()
    {
        Debug.Log("OnClick");
        JSONNode N = new JSONObject();


        N["voornaam"] = voornaam;
        N["achternaam"] = achternaam;
        N["deviceId"] = SystemInfo.deviceUniqueIdentifier.ToString();
        Debug.Log(N);

        Info.Voornaam = voornaam;
        Info.SpelerNaam = voornaam + " " + achternaam;
        

        if (voornaam != "" && achternaam != "")
        {
            api.ApiPost(url, N);
            button.interactable = true;
        }

        

       
    }
    
}
