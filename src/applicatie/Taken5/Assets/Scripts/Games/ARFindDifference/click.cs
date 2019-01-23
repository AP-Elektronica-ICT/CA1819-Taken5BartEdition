using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour {

    public GameObject antwoord;
    public int itemID;
    // Use this for initialization$
    void Start () {
        
	}


    // Update is called once per frame
    void Update()
    {
        /*
        // Code for OnMouseDown in the iPhone. Unquote to test.
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.collider.gameObject.GetComponent<>
                    if (this.gameObject.activeSelf)
                    {
                        Debug.Log("you hit me");
                        Object.GetComponent<antwoord>().foundItem(itemID);
                    }
                    Debug.Log("hit");
                    
                }
            }
        }
        */
    }

    public void objectClick()
    {
        antwoord.GetComponent<FTDantwoord>().foundItem(itemID);
    }
}
