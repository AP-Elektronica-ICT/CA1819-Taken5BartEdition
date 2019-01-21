using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndInventoryItemDisplay : MonoBehaviour
{
    public Image image;
    public Text txtTeamnaam;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void prime(EndInventoryItem item)
    {
        txtTeamnaam.text = item.teamnaam;
        txtScore.text = item.score;
        if (item.image != null)
        {
            image = item.image;
        }


    }
}
