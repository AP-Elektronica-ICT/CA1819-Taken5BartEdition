using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteenGameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        try { 
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Application.LoadLevel("SteenGame");
        }
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
