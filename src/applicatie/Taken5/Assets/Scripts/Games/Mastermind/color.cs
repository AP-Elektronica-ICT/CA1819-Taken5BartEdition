using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour {
    List<UnityEngine.Color> colorList = new List<Color>()
    {
        UnityEngine.Color.red,
        UnityEngine.Color.blue,
        UnityEngine.Color.green,
        UnityEngine.Color.yellow,
        new Color(255,93,0), //orange
        UnityEngine.Color.black,
    };
    int counter;

    public int Id;
    public UnityEngine.Color SelecctedColor { get { return colorList[counter]; } }
    public int SelecctedColorId { get { return counter; } }
    public Image panel;
	// Use this for initialization
	void Start () {
        counter = (int)(Random.value * (colorList.Count-1));
        panel.color = colorList[counter];
    }
	
	// Update is called once per frame
    public void BtnUp()
    {
        counter = (counter+1) % colorList.Count;
        panel.color = colorList[counter];
        //Debug.Log("down");
        //Debug.Log(counter);
    }

    public void BtnDown()
    {
        if (counter <= 0)
            counter = colorList.Count;
        counter = (counter - 1);
        panel.color = colorList[counter];
        //Debug.Log("up");
        //Debug.Log(counter);
    }
}
