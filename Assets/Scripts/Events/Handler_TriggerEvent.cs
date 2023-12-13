using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

public class Handler_TriggerEvent : MonoBehaviour
{

    public string eventName;

    public void Trigger()
    {
        EventManager.TriggerEvent(eventName);
    }

}
