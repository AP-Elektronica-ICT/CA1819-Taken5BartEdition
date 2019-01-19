using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // public List<PuzzelDone> puzzelDones = Info.puzzelDones;
    public List<InventoryItem> items = new List<InventoryItem>();
    APICaller api;
    string url = "score/1";//+ Info.TeamId;
    string totalurl = "score/" + Info.TeamId + "/total";
    int totalscore;
    public InventoryDisplay inventoryDisplayPrefab;
    InventoryDisplay inventory;
    // Use this for initialization
    void Start ()
    {

        AddGameDiamant("Started Game", "10");
        inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
        api = gameObject.AddComponent<APICaller>();
        api.ApiGet(url, getScores);

    }

    void getScores(string json)
    {
        var N = JSON.Parse(json);
        AddGameDiamant("startgame", N["startgame"].Value.ToString());
        AddGameDiamant("vlaamsekaai", N["vlaamsekaai"].Value.ToString());
        AddGameDiamant("stadsfeestzaal", N["stadsfeestzaal"].Value.ToString());
        AddGameDiamant("kathedraal", N["kathedraal"].Value.ToString());
        AddGameDiamant("vleaykensgang", N["vleaykensgang"].Value.ToString());
        AddGameDiamant("grotemarkt", N["grotemarkt"].Value.ToString());
        AddGameDiamant("mas", N["mas"].Value.ToString());
        AddGameDiamant("havenhuis", N["havenhuis"].Value.ToString());
        inventory.Prime(items);

    }

    public void AddGameDiamant(string naam, string score)
    {
        Debug.Log("naam " + naam + "score " + score);
        if (score != "0")
        {
            InventoryItem item = gameObject.AddComponent<InventoryItem>();
            item.naam = naam;
            item.score = score;
            items.Add(item);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
