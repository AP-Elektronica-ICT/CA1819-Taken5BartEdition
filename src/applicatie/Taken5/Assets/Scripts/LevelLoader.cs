using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        Debug.Log(sceneIndex.ToString());
        StartCoroutine(LoadAsychronously(sceneIndex));
    }

    IEnumerator LoadAsychronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            
             yield return null;
            
        }
    }


}
