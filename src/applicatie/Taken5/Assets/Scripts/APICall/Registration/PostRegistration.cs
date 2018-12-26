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
    public string json = "";

    public APICaller api;
    CheckRegisterd checkRegisterd;

    void Start()
    {
        Debug.Log("trste");
        api = gameObject.AddComponent<APICaller>();
    }
    void Update()
    {
      
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


        if (voornaam != "" && achternaam != "")
        {
            api.ApiPost(url, N);
            Debug.Log("posted");
            button.interactable = true;

        }

    }
    
  
}
