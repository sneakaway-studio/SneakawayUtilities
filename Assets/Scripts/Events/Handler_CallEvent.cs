using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/** 
 *  LISTEN for event => Load a prefab as a child
 */

public class Handler_CallEvent : MonoBehaviour
{
    [Tooltip("Object to load")]
    [SerializeField] GameObject prefab;

    [Tooltip("The event that will trigger this listener")]
    [SerializeField] string eventName = "";

    [Tooltip("Number of times event can be triggered (-1 for infinity)")]
    [SerializeField] int triggerLimit = -1;

    [Tooltip("Event has been received")]
    [SerializeField] int triggered;

    [Tooltip("Max prefabs allowed")]
    [SerializeField] int maxPrefabs = 1;

    [Tooltip("Loaded prefab")]
    [SerializeField] GameObject loaded;

    //[Tooltip("Delay in seconds")]
    //[SerializeField] float delay;

    private void OnEnable()
    {
        EventManager.StartListening(eventName, Trigger);
    }
    private void OnDisable()
    {
        EventManager.StopListening(eventName, Trigger);
    }

    void Trigger()
    {
        Debug.Log("Listener_LoadPrefab.Trigger()");
        // only once
        if (triggerLimit < 0 || triggered < triggerLimit)
        {
            if (loaded != null && transform.childCount >= maxPrefabs)
            {
                Destroy(loaded);
            }
            triggered++;
            loaded = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            loaded.transform.SetParent(transform, false);
            loaded.transform.localScale = Vector3.one;
            loaded.transform.localPosition = Vector3.zero;
        }
    }

}
