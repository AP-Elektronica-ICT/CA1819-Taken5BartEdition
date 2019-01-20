using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamListDisplay : MonoBehaviour {

    public Transform targetTransform;
    public TeamListItemDisplay itemDisplayPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Prime(List<TeamListItem> items)
    {
        foreach (TeamListItem item in items)
        {
            TeamListItemDisplay display = (TeamListItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Prime(item);
        }
    }
}
