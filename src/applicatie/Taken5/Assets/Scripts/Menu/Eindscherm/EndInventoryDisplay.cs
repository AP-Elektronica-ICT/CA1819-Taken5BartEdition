using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndInventoryDisplay : MonoBehaviour
{

    public Transform targetTransform;
    public EndInventoryItemDisplay itemDisplayPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Prime(List<EndInventoryItem> items)
    {
        foreach (EndInventoryItem item in items)
        {
            Debug.Log(item);
            EndInventoryItemDisplay display = (EndInventoryItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.prime(item);

        }
    }
}
