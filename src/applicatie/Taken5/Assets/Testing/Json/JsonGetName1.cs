using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonGetName1 : MonoBehaviour {

    public string url = "http://localhost:1907/api/Speler/1";
    // Use this for initialization
    public Text SpelerNaam;

    IEnumerator Start()
    {
        SpelerNaam.text = "my test";
        Debug.Log("hi");
        using (WWW www = new WWW(url))
        {
            yield return www;
            string json = www.text;
            Debug.Log(json);
            Speler speler = JsonUtility.FromJson<Speler>(json);
            Debug.Log(((Speler)JsonUtility.FromJson<Speler>(json)).achternaam); //Type casting!!!
            Debug.Log(speler.voornaam);
            SpelerNaam.text = speler.voornaam;
        }
    }

    [Serializable]
    private class Speler
    {
        public int id;
        public string voornaam;
        public string achternaam;
    }
}


