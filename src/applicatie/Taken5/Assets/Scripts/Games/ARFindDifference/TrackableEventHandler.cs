using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackableEventHandler : DefaultTrackableEventHandler
{
    public Button button;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        button.gameObject.SetActive(true);
    }
}
