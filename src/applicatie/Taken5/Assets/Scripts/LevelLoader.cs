using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;
    public Dropdown dropdown;
    int nextlevel;
    APICaller _api;
    bool SceneIsLoaded = false;

    void Start()
    {
        _api = gameObject.AddComponent<APICaller>();
    }
    public void LoadLevel(int sceneIndex)
    {
     //   Debug.Log(sceneIndex.ToString());
        StartCoroutine(LoadAsychronously(sceneIndex));
       
    }

    public void LoadNextLevel()
    {
        
        int mode = dropdown.value;
        int modeIndex;

        if (mode == 0)
        { 
            modeIndex = Info.ActivePuzzel;
        }
        else
        {
            modeIndex = dropdown.value - 1;


            switch (modeIndex)
            {
                case 0:
                    //vlaamsekaai
                    nextlevel = 12;
                    break;

                case 1:
                    //stadsfeestzaal - quiz
                    nextlevel = 9;
                    break;

                case 2:
                    //Kathedraal
                    nextlevel = 11;
                    break;

                case 3:
                    //vleaykensgang
                    nextlevel = 10;
                    break;

                case 4:
                    //grotemarkt - brabo
                    nextlevel = 7;
                    break;

                case 5:
                    //het steen - platformer
                    nextlevel = 8;
                    break;

                case 6:
                    // museum aan de stroom 
                    nextlevel = 10;
                    break;

                case 7:
                    // havenhuis
                    nextlevel = 10;
                    break;

            }
            Info.loadlevel = nextlevel;
            ChangeGameMode(_api);
        }



    }

    public void ChangeGameMode(APICaller apicaller)
    {
        Debug.Log("changegamemode");
        StartCoroutine(apicaller.Get("team/" + Info.TeamId+ "/" + Info.spelerId + "/changegamemode", EndGameAction));

    }

    public void ChangeGameModeEndOfGame(APICaller apicaller, string locatienaam, double score)
    {
        Debug.Log("changegamemode");
        StartCoroutine(apicaller.GetEndOfGame("team/" + Info.TeamId + "/" +Info.spelerId +"/changegamemode", locatienaam,score, apicaller, EndGameActionfinal));

    }

    public void EndGameActionfinal(string json, string locatienaam, double score, APICaller API)
    {
        Debug.Log("json for score is" + json);
        if (json == "3")
        {
            Debug.Log("score/" + Info.TeamId + "/" + locatienaam + "/" + score);

            StartCoroutine(API.Get("score/" + Info.TeamId + "/" + locatienaam + "/" + score, donothing));
            StartCoroutine(API.Get("team/" + Info.TeamId + "/nextpuzzel",  donothing));
        }
        EndGameAction(json);
    }   
    void donothing(string json)
    { Debug.Log("score is " + json); }
    public void EndGameAction(string json)
    {
        Debug.Log("gamemode = " + json);
        switch (json)
        {

            case "0":
                Debug.Log("case0");
                SceneIsLoaded = false;
                StartCoroutine(LoadAsychronously(4));
                break;

            case "1":
                if (!SceneIsLoaded)
                {
                    Debug.Log("case1");
                    StartCoroutine(LoadAsychronously(13));
                    SceneIsLoaded = true;

                }
                break;
            case "2":
                Debug.Log("case2 and nextlevel" + Info.loadlevel);

                SceneIsLoaded = false;
                StartCoroutine(LoadAsychronously(Info.loadlevel));
                break;

            case "3":
                Debug.Log("case3");

                if (!SceneIsLoaded)
                {
                    StartCoroutine(LoadAsychronously(13));
                    SceneIsLoaded = true;
                }           
                break;

        }
    }
    IEnumerator LoadAsychronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Debug.Log("loading scene " + sceneIndex);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            
             yield return null;
            
        }
    }


}
