using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Antwoord : MonoBehaviour {
    private string opl = "aliens";
    public Text txtAntwoord;
    public Text inAntwoord;
    public GameObject delijn;
    public GameObject kruitvat;
    public GameObject ASAdventure;
    public GameObject Hema;
    public GameObject Score;
    public GameObject JaJ;
    public Button btnTryAnswer;
    public Image correct;
    public Image wrong;

    public int navLevelID;

    private APICaller _api;
    private bool _updating;

    // Use this for initialization
    void Start () {
        Info.TeamId = 2;
        _api = gameObject.AddComponent<APICaller>();
        StartCoroutine(_api.Put("Team/" + Info.TeamId + "/SetActivePuzzel?reset=false",new JSONObject(), result));
        _updating = true;
        txtAntwoord.text = opl.ToUpper();
        var charopl = opl.ToCharArray();
        setupText(delijn.GetComponentsInChildren<TextMesh>(true), charopl[0]);
        setupText(kruitvat.GetComponentsInChildren<TextMesh>(true), charopl[1]);
        setupText(ASAdventure.GetComponentsInChildren<TextMesh>(true), charopl[2]);
        setupText(Hema.GetComponentsInChildren<TextMesh>(true), charopl[3]);
        setupText(Score.GetComponentsInChildren<TextMesh>(true), charopl[4]);
        setupText(JaJ.GetComponentsInChildren<TextMesh>(true), charopl[5]);
        
    }

    void result(string json)
    {
        Debug.Log(json);
        if(json == "-1")
        {
            Debug.Log("returning to nav");
            backToNav("-1");
        }
        else
        {
            var N = JSON.Parse(json);
            Debug.Log(N["id"].Value);
            StartCoroutine(resetUpdate());
        }
    }

    IEnumerator resetUpdate()
    {
        yield return new WaitForSeconds(5);
        _updating = false;
    }

    void Update()
    {
        if (!_updating)
        {
            _updating = true;
            StartCoroutine(_api.Get("Team/" + Info.TeamId + "/ActivePuzzel", result));
        }
    }

    void setupText(TextMesh[] texts, char c)
    {
        texts[0].text = c.ToString();
        texts[1].text = c.ToString();
    }
	
	public void Answer()
    {
        btnTryAnswer.gameObject.SetActive(false);
        string user = inAntwoord.text.ToLower();
        if(opl == user)
        {
            Debug.Log("correct");
            StartCoroutine(_api.Put("Team/" + Info.TeamId + "/SetActivePuzzel?reset=true", new JSONObject(), backToNav));
            correct.gameObject.SetActive(true);
        }
        else
        {
            wrong.gameObject.SetActive(true);
            StartCoroutine(delayInput());
        }
    }

    IEnumerator delayInput()
    {
        yield return new WaitForSeconds(10);
        correct.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);
        btnTryAnswer.gameObject.SetActive(true);
    }
    void backToNav(string json)
    {
        LevelLoader l = gameObject.AddComponent<LevelLoader>();
        l.LoadLevel(navLevelID);
    }
}
