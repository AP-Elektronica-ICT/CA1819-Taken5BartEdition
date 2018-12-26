using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackableEventHandler : DefaultTrackableEventHandler
{
    public GameObject found;
    public GameObject lost;

    protected override void OnTrackingFound()
    {
        found.gameObject.SetActive(true);
        lost.gameObject.SetActive(false);
        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        found.gameObject.SetActive(false);
        lost.gameObject.SetActive(true);
        base.OnTrackingLost();
    }
}
