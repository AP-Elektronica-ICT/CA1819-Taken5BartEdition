using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

    public static GPS Instance { get; set; }

    public float latitude;
    public float longitude;
    public Text lat;
    public Text lon;
    public Text updateTime;
    DateTime lastTime;

    void Start ()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        StartCoroutine(startLocationService());		
	}

    private IEnumerator startLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("user has not enabled GPS");
            yield break;
        }

        Input.location.Start(1,5); 
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("unable to determin device lcoation");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        lastTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update () {
        if (!Input.location.isEnabledByUser)
            return;
        if (Input.location.status == LocationServiceStatus.Failed)
            return;

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        if(lat != null)
        {
            if(latitude.ToString() != lat.text)
            {
                updateTime.text = (DateTime.Now - lastTime).ToString();
                lastTime = DateTime.Now;
            }
            lat.text = latitude.ToString();
            lon.text = longitude.ToString();
        }
    }

    
}
