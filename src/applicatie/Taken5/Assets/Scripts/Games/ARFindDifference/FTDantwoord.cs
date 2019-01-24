using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FTDantwoord : MonoBehaviour {

    private int[] foundItems;
    int itemCount;
    bool isDone = true;
    public int activeElement;
    public Text score;
    public GameObject items;

    APICaller _api;
    DateTime starttijd;
    LevelLoader levelLoader;

    //public antwoord scripts;
    // Use this for initialization
    void Start () {
        _api = gameObject.AddComponent<APICaller>();
        levelLoader = gameObject.AddComponent<LevelLoader>();
        JSONNode N = new JSONObject();
        N["teamID"] = Info.TeamId;
        N["itemCount"] = itemCount;
        _api.ApiPost("FTD", N);
        starttijd = DateTime.Now;
        /*
        itemCount = items.transform.childCount;
        foundItems = new int[itemCount];
		for(int i= 0; i < itemCount; i++)
        {
            foundItems[i] = 0;
        }
        */
	}
	
    public void foundItem(int id)
    {
        Debug.Log("item found:" + id.ToString());
        foundItems[id] = 1;
        _api.ApiGet("FTD/" + Info.TeamId + "/found?itemId=" + id);
    }
	// Update is called once per frame
	void Update () {
        if (isDone)
        {
            isDone = false;
            _api.ApiGet("FTD/" + Info.TeamId, AfterUpdate);
            /*
            int result = 0;
            foreach (int i in foundItems)
            {
                result += i;
            }
            if(result>= itemCount) //itemCount)
            {
                var timeresult = (DateTime.Now - starttijd).Minutes;
                float finalResult = 0;
                if(timeresult< 3)
                {
                    finalResult = 10;
                }
                else if (timeresult < 8)
                {
                    finalResult = 13 - timeresult;
                }
                else if (timeresult < 13)
                {
                    finalResult = 5- ((timeresult - 8) * 0.5f);
                }
                else
                {
                    finalResult = 0;
                }
                Debug.Log("all found");
                levelLoader.ChangeGameModeEndOfGame(_api, "Kathedraal", finalResult);
            }
            score.text = result + "/" + itemCount;
            Debug.Log(result);
            StartCoroutine(UpdateDelayed());
            */
        }
	}

    public void AfterUpdate(string json)
    {
        if (json == "0")
        {
            var timeresult = (DateTime.Now - starttijd).Minutes;
            float finalResult = 0;
            if (timeresult < 3)
            {
                finalResult = 10;
            }
            else if (timeresult < 8)
            {
                finalResult = 13 - timeresult;
            }
            else if (timeresult < 13)
            {
                finalResult = 5 - ((timeresult - 8) * 0.5f);
            }
            else
            {
                finalResult = 0;
            }
            Debug.Log("all found");
            levelLoader.ChangeGameModeEndOfGame(_api, "Kathedraal", finalResult);
        }
        var result = itemCount - int.Parse(json);
        score.text = result + "/" + itemCount;
        Debug.Log(result);
        StartCoroutine(UpdateDelayed());
    }

    public IEnumerator UpdateDelayed()
    {
        yield return new WaitForSeconds(15);
        isDone = true;
    }


}
