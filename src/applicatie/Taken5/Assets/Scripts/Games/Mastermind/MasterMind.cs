using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMind : MonoBehaviour {
    //int[] trueAnswer = { 1, 2, 3, 4 };

    public GameObject correctColors;
    public GameObject correct;
    public Button btnTryAnswer;
    public int navLevelID;

    private bool _updating;
    private APICaller _api;
    DateTime starttijd;
    LevelLoader levelLoader;
    int guesses;

    // Use this for initialization
    void Start () {
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        starttijd = DateTime.Now;

        _updating = false;
        btnTryAnswer.gameObject.SetActive(true);
        _api = gameObject.AddComponent<APICaller>();
        JSONNode N = new JSONObject();
        N["assignedTeamId"] = Info.TeamId;
        _api.ApiPost("MasterMind", N);
    }
	
	// Update is called once per frame
	void Update () {
        if (!_updating)
        {
            _updating = true;
            /*
            Debug.Log(compareResult());
            int[] result = compareResult();
            Debug.Log("correct:"+result[0]);
            Debug.Log("color only:" + result[1]);
            showResult(result);
            */
            var url = "MasterMind/" + Info.TeamId.ToString() + "/Allfound";
            string current = "";
            current += GameObject.Find("c1").GetComponent<color>().SelecctedColorId.ToString();
            current += GameObject.Find("c2").GetComponent<color>().SelecctedColorId.ToString();
            current += GameObject.Find("c3").GetComponent<color>().SelecctedColorId.ToString();
            current += GameObject.Find("c4").GetComponent<color>().SelecctedColorId.ToString();
            Debug.Log(current);
            _api.ApiGet(url, Allfound);
            
        }
    }

    public void Allfound(string json)
    {
        Debug.Log(json);
        if(json == "true")
        {
            Debug.Log("all found, ending game");
            var url = "MasterMind/" + Info.TeamId.ToString();
            _api.ApiGet(url, backToNav);
        }
        StartCoroutine(resetUpdate());
    }

    public void TryAnswer()
    {
        btnTryAnswer.gameObject.SetActive(false);
        
        var N = new SimpleJSON.JSONObject();
        N["teamID"] = Info.TeamId;
        N["answers"][0] = GameObject.Find("c1").GetComponent<color>().SelecctedColorId;
        N["answers"][1] = GameObject.Find("c2").GetComponent<color>().SelecctedColorId;
        N["answers"][2] = GameObject.Find("c3").GetComponent<color>().SelecctedColorId;
        N["answers"][3] = GameObject.Find("c4").GetComponent<color>().SelecctedColorId;
        _api.ApiPost("MasterMind/try", N,showResult);
    }
    
    IEnumerator resetUpdate()
    {
        yield return new WaitForSeconds(3);
        _updating = false;
    }

    void backToNav(string json)
    {
        var N = new SimpleJSON.JSONObject();
        var timeresult = (DateTime.Now - starttijd).Minutes;
        float finalResult = 0;
        if (timeresult < 3)
        {
            finalResult = 100;
        }
        else if (timeresult < 10)
        {
            finalResult = 103 - timeresult;
        }
        else
        {
            finalResult = 85 - ((timeresult - 10) * 0.5f);
        }
        finalResult = (finalResult - (guesses * 0.25f))/10;
        Debug.Log("all found");
        levelLoader.ChangeGameModeEndOfGame(_api, "havenhuis", finalResult);
    }

    public void showResult(string json)
    {
        var N = JSON.Parse(json);
        int[] result = new int[2];
        result[0] = N[0].AsInt;
        result[1] = N[1].AsInt;
        var corCol = correctColors.transform.GetComponentsInChildren<Image>(true);
        var cor = correct.transform.GetComponentsInChildren<Image>(true);

        for (int i = 0; i < 4; i++)
        {
            if(result[0] > i)
            {
                corCol[i].gameObject.SetActive(true);
            }
            else
            {
                corCol[i].gameObject.SetActive(false);
            }

            if (result[1] > i)
            {
                cor[i].gameObject.SetActive(true);
            }
            else
            {
                cor[i].gameObject.SetActive(false);
            }
        }
        btnTryAnswer.gameObject.SetActive(true);
        /*
        GameObject.Find("n1").SetActive(false);
        GameObject.Find("n2").SetActive(false);
        GameObject.Find("n3").SetActive(false);
        GameObject.Find("n4").SetActive(false);
        GameObject.Find("p (1)").SetActive(false);
        GameObject.Find("p (2)").SetActive(false);
        GameObject.Find("p (3)").SetActive(false);
        GameObject.Find("p (4)").SetActive(false);

        if (result[0] >= 1)
        {
            GameObject.Find("n1").SetActive(true);
        }
        if (result[0] >= 2)
        {
            GameObject.Find("n2").SetActive(true);
        }
        if (result[0] >= 3)
        {
            GameObject.Find("n3").SetActive(true);
        }
        if (result[0] >= 4)
        {
            GameObject.Find("n4").SetActive(true);
        }

        if (result[1] >= 1)
        {
            GameObject.Find("p (1)").SetActive(true);
        }
        if (result[1] >= 2)
        {
            GameObject.Find("p (2)").SetActive(true);
        }
        if (result[1] >= 3)
        {
            GameObject.Find("p (3)").SetActive(true);
        }
        if (result[1] >= 4)
        {
            GameObject.Find("p (4)").SetActive(true);
        }
        */
    }
    /*
    int[] compareResult()
    {
        int[] result = { 0, 0 };
        int[] anwser = new int[4];
        anwser[0] = GameObject.Find("c1").GetComponent<color>().SelecctedColorId;
        anwser[1] = GameObject.Find("c2").GetComponent<color>().SelecctedColorId;
        anwser[2] = GameObject.Find("c3").GetComponent<color>().SelecctedColorId;
        anwser[3] = GameObject.Find("c4").GetComponent<color>().SelecctedColorId;
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(anwser[i] + ":" + trueAnswer[i]);
            if (anwser[i] == trueAnswer[i])
            {
                result[0]++;
            }
        }

        int[] tmpAnwser = (int[])trueAnswer.Clone();
        for (int i = 0; i < 4; i++)
        {
            bool notFound = true;
            for (int j = 0; j < 4; j++)
            {
                if ((anwser[j] == tmpAnwser[i]) & notFound)
                {
                    result[1]++;
                    tmpAnwser[i] = -1;
                    notFound = false;
                }
            }
        }
        return result;
    }
    */
}
