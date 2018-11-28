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

    // Use this for initialization
    void Start()
    {
        url = "http://localhost:1907/api/speler/register/" + SystemInfo.deviceUniqueIdentifier.ToString();
        StartCoroutine(Get());
    }
    
    IEnumerator Get()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            var N = JSON.Parse(json);
            Debug.Log(N);

            if (N != "")
            {
                textvoornaam = "test";//N["voornaam"].Value.ToString();
                textachternaam = N["achternaam"].Value.ToString();
                button1.interactable = false;
                button2.interactable = true;
                updatetext();
            }
        }
    }
    void updatetext()
    {
        voornaam.text = textvoornaam;
        achternaam.text = textachternaam;
    }
}
