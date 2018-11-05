using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsArrow : MonoBehaviour {

    public RectTransform rectTransform;
    int angle = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        angle = angle + 1;
        rectTransform.Rotate(0, 0, angle);
    }
}
