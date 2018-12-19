using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour {
    public Text puzzelnaam;
    public Text score;
    
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Prime(InventoryItem item)
    {
        if (puzzelnaam != null)
        {
            puzzelnaam.text = item.naam;
            score.text = item.score;
        }
    }
}
