using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisable : MonoBehaviour {

    public Button button;
    public Text x;
    string empty;
    // Update is called once per frame
    public void onclick () {
        empty = x.text;
        Debug.Log(empty);
        if (empty == "")
        {
            button.enabled = false;
            Debug.Log("disabled");
        }
        else
            button.enabled = true;

		
	}
}
