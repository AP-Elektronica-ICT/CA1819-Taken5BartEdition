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
    public void LoadLevel(int sceneIndex)
    {
     //   Debug.Log(sceneIndex.ToString());
        StartCoroutine(LoadAsychronously(sceneIndex));
        _api = gameObject.AddComponent<APICaller>();
    }

    public void LoadNextLevel()
    {
        nextlevel = 0;
        int mode = dropdown.value;
        int modeIndex;

        if (mode == 0)
        { 
            modeIndex = Info.ActivePuzzel;
            ChangeGameMode(Info.TeamId, _api);
        }
        else
        {
            modeIndex = dropdown.value - 1;


            switch (modeIndex)
            {
                case 0:
                    //vlaamsekaai
                    nextlevel = 10;
                    break;

                case 1:
                    //stadsfeestzaal - quiz
                    nextlevel = 9;
                    break;

                case 2:
                    //Kathedraal
                    nextlevel = 10;
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
        }



    }




     public void ChangeGameMode(int teamid, APICaller apicaller)
    {
        Debug.Log("changegamemode");
        StartCoroutine(apicaller.Get("team/" + teamid.ToString() + "/changegamemode", EndGameAction));

    }
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
                Debug.Log("case2");

                SceneIsLoaded = false;
                StartCoroutine(LoadAsychronously(nextlevel));
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
        Debug.Log("loading" + sceneIndex);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            
             yield return null;
            
        }
    }


}
