using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public Text TeamNaam;
    public Text puzzelsdone;
    public Text totaal;
    APICaller api;

    public Transform targetTransform;
    public InventoryItemDisplay itemDisplayPrefab;
    int counter;
    string total = "score/" + Info.TeamId + "/total";

    void Start ()
    {
        api = gameObject.AddComponent<APICaller>();
        api.ApiGet(total, getScores);

        counter = 0;
        if (Info.TeamNaam == null)
        {
            TeamNaam.text = "nog geen team --> demo";
        }
        else { 

            TeamNaam.text = Info.TeamNaam;
        }

    }
    void getScores(string json)
    {
        Debug.Log(json);
        totaal.text = json;
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
    public void Prime(List<InventoryItem> items)
    {
        foreach (InventoryItem item in items)
        {
           // Debug.Log(item);
            InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Prime(item);
            counter++;
            puzzelsdone.text = counter.ToString();
        }
    }
}
