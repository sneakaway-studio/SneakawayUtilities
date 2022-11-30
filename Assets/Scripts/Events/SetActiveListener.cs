using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/**
 *  Set an object active | inactive on Event
 */

namespace SneakawayUtilities
{
	public class SetActiveListener : MonoBehaviour
	{
	    [Tooltip("Object to affect")]
	    [SerializeField] GameObject obj;

	    [Tooltip("Event name that triggers this listener")]
	    [SerializeField] string eventName = "";

	    [Tooltip("Default state before event")]
	    [SerializeField] bool initialState = false;

	    [Tooltip("State after event")]
	    [SerializeField] bool triggeredState = false;

	    [Tooltip("If event has occurred")]
	    [SerializeField] bool triggered = false;

	    [Tooltip("Delay (in seconds) before state changes")]
	    [SerializeField] float delay;

	    void Awake()
	    {
	        // initial state
	        obj.SetActive(initialState);
	    }
		/* To disable in Inspector */
		void Start() {}

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
	        // only change the state once
	        if (!triggered) return;
	        triggered = true;

			// change the state after a delay
			Invoke("UpdateState", delay);
	    }

		void UpdateState() => obj.SetActive(triggeredState);


	}
}
