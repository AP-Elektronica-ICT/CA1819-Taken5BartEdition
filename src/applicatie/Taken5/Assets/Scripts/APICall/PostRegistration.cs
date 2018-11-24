using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostRegistration : MonoBehaviour
{

    static string url = "http://localhost:1907/api/speler";

    public void onclick()
        {
            Debug.Log("start");
            JSONNode N = new JSONObject();
           

            N["voornaam"] = "sdfsdf";
            N["achternaam"] = "sdfsdf";
            N["deviceId"] = 269;
            Debug.Log(N);
            StartCoroutine(WWWPost(N));
        }

    // Update is called once per frame
    public static IEnumerator WWWPost(JSONNode N)
        {
            var req = new UnityWebRequest(url, "POST");
            byte[] data = Encoding.UTF8.GetBytes(N.ToString());

            req.uploadHandler = new UploadHandlerRaw(data);
            req.uploadHandler.contentType = "application/json";
            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("accept", "application/json");

            yield return req.SendWebRequest();

            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }

        }
    }
