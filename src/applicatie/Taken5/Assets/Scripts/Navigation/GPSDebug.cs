using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSDebug : MonoBehaviour
{
    // Start is called before the first frame update
    public Text lat;
    public Text lon;
    GPS _gps;
    void Start()
    {
        _gps = gameObject.AddComponent<GPS>();
    }

    // Update is called once per frame
    void Update()
    {
        lat.text = _gps.latitude.ToString();
        lon.text = _gps.longitude.ToString();
    }
}
