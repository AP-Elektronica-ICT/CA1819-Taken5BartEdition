using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsArrow : MonoBehaviour {

    public RectTransform rectTransform;
    double angle = 0;
    double lat;
    double lon;

    // Use this for initialization
    void Start () {
        lat = GPS.Instance.latitude;
        lon = GPS.Instance.longitude;
    }
	
	// Update is called once per frame
	void Update () {
        lat = GPS.Instance.latitude;
        lon = GPS.Instance.longitude;

        double yDiff = 51.229957 - 90;
        double xDiff = 4.416269 - 0;
        angle = -(Math.Atan(xDiff / yDiff) * (180/Math.PI));

        rectTransform.eulerAngles = new Vector3(0, 0, (float)angle);
    }
}
