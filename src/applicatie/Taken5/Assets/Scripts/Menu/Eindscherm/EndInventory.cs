using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;

public class EndInventory : MonoBehaviour
{
    public List<EndInventoryItem> items = new List<EndInventoryItem>();
    APICaller api;
    string url = "sessie/" + 1;
    int totalscore;
    public EndInventoryDisplay inventoryDisplayPrefab;
    EndInventoryDisplay inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = (EndInventoryDisplay)Instantiate(inventoryDisplayPrefab);
        api = gameObject.AddComponent<APICaller>();
        api.ApiGet(url, getScores);
    }
    void getScores(string json)
    {
        Debug.Log(json);
        var N = JSON.Parse(json);

        for (int i = 0; i < 8; i++)
        {
            if (N["teams"][i]["teamNaam"].Value != "")
            {
                AddScore(N["teams"][i]["teamNaam"].Value, N["teams"][i]["puzzelScores"]["totaal"].Value);

            }
        }

        items.Sort(SortByScore);
        items.Reverse();
        foreach (EndInventoryItem item in items)
        {
            Debug.Log(item.score);
        }
        inventory.Prime(items);

    }
    private static int SortByScore(EndInventoryItem o1, EndInventoryItem o2)
    {
        return o1.score.CompareTo(o2.score);
    }
    public void AddScore(string teamNaam, string score)
    {
        Debug.Log("naam " + teamNaam + "score " + score);

        EndInventoryItem item = gameObject.AddComponent<EndInventoryItem>();
        item.teamnaam = teamNaam;
        item.score = score;
        items.Add(item);
    }

}

