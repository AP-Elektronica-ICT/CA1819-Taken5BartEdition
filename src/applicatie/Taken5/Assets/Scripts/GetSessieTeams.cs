using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetSessieTeams : MonoBehaviour {

    public GameObject joinTeam;
    public Slider slider;
    public Text code;
    public static string sessieCode;

    public void LoadJoinTeam(int sceneIndex)
    {
        sessieCode = code.text;
        StartCoroutine(LoadAsychronously(sceneIndex));
    }

    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        slider.gameObject.SetActive(true);
        joinTeam.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;

        }
    }
}
