using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // public List<PuzzelDone> puzzelDones = Info.puzzelDones;
    public List<InventoryItem> items = new List<InventoryItem>();


    public InventoryDisplay inventoryDisplayPrefab;
	// Use this for initialization
	void Start ()
    {
        AddGameDiamant("Started Game", "10");
        InventoryDisplay inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
        inventory.Prime(items);
	}
	
    public void AddGameDiamant(string naam, string score)
    {
        InventoryItem item = gameObject.AddComponent<InventoryItem>();
        item.naam = naam;
        item.score = score;
        items.Add(item);


    }
    // Update is called once per frame
    void Update () {
		
	}
}
