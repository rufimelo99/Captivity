using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsTrigger : MonoBehaviour
{

    public enum AnalyticsEvent
    {
            EnteredRoomA,
            EnteredRoomB,

    }

    public AnalyticsEvent analyticEventTobeTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         AnalyticsResult analyticsResult = Analytics.CustomEvent(analyticEventTobeTriggered.ToString()); 
    }
}
