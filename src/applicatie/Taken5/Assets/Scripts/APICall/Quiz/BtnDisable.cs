using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisable : MonoBehaviour {
    public Button button1;
    public Button button2;
    public Text x;
    public Text y;




    string empty1;
    string empty2;

   
    // Update is called once per frame
    public void onclick () {
        
        empty1 = x.text;
        empty2 = y.text;
     
        if (empty1 == "")
        {
            button1.interactable = false;
            Debug.Log("disabled");
        }
        else
            button1.interactable = true;

        if (empty2 == "")
        {
            button2.interactable = false;
            Debug.Log("disabled");
        }
        else
            button2.interactable = true;

    }
    public void OnWrongQuess(Button btn)
    {
        btn.interactable = false;
    }
    public void EnableAllButtons(Button[] buttons)
    {
        foreach (Button b in buttons)
        {
            b.interactable = true;
        }

    }
}
