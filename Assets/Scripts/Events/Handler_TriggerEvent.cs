using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

public class Handler_TriggerEvent : MonoBehaviour
{

    public string eventName;

    public void Trigger()
    {
        // if not working set debug=true in EventManager
        //Debug.Log("Handler_TriggerEvent() > " + eventName);
        EventManager.TriggerEvent(eventName);
    }

}
