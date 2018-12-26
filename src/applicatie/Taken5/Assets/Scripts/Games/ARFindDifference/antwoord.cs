using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antwoord : MonoBehaviour {
    private int[] foundItems;
    int itemCount = 4;
    bool isDone = true;

    //public antwoord scripts;
	// Use this for initialization
	void Start () {
        foundItems = new int[itemCount];
		for(int i= 0; i < itemCount; i++)
        {
            foundItems[i] = 0;
        }
	}
	
    public void foundItem(int id)
    {
        Debug.Log("item found:" + id.ToString());
        foundItems[id] = 1;
    }
	// Update is called once per frame
	void Update () {
        if (isDone)
        {
            isDone = false;
            int result = 0;
            foreach (int i in foundItems)
            {
                result += i;
            }
            Debug.Log(result);
            StartCoroutine(UpdateDelayed());
        }
	}

    public IEnumerator UpdateDelayed()
    {
        yield return new WaitForSeconds(15);
        isDone = true;
    }
}
