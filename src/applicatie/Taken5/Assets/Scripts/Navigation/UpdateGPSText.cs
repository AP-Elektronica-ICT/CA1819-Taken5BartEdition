using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {

    public Text coordinates;
	
	
	// Update is called once per frame
	void Update ()
    {
        coordinates.text = "lat: " + GPS.Instance.latitude.ToString() + "  Lon" + GPS.Instance.longitude.ToString();
	}

   
}
