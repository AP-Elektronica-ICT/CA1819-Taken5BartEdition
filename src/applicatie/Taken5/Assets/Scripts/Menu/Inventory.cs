using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // public List<PuzzelDone> puzzelDones = Info.puzzelDones;
    public List<InventoryItem> items = new List<InventoryItem>();
    InventoryItem item = new InventoryItem();
    InventoryItem item1 = new InventoryItem();
    InventoryItem item2 = new InventoryItem();
    InventoryItem item3 = new InventoryItem();
    InventoryItem item4 = new InventoryItem();
    InventoryItem item5 = new InventoryItem();

    public InventoryDisplay inventoryDisplayPrefab;
	// Use this for initialization
	void Start ()
    {
        item.naam = "Kathedraal";
        item1.naam = "Stadsfeestzaal";
        item2.naam = "Mas";
        item3.naam = "X";
        item4.naam = "Y";
        item5.naam = "Z";


        items.Add(item);
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);


        InventoryDisplay inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
        inventory.Prime(items);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
