using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/**
 *  Instantiate an object on Event
 */

namespace SneakawayUtilities
{
    public class InstantiateOnEvent : MonoBehaviour
    {
        [Tooltip("The prefab to create")]
        public GameObject prefab;

        [Tooltip("Event name that triggers this listener")]
        [SerializeField] string eventName = "";

        [Tooltip("Collider for bounds")]
        public BoxCollider boxCollider;

        [Tooltip("Default to this position if no box collider is present")]
        public Vector3 initialPosition;

        [Tooltip("Number of objects to create")]
        public int count = 1;



        private void Awake()
        {
            //boxCollider = GetComponent<BoxCollider>();
            // if no eventName stored, instantiate on awake
            if (eventName == "") Trigger();
        }

        /* To disable in Inspector */
        void Start() { }

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
            for (int i = 0; i < count; i++)
            {
                if (boxCollider != null) initialPosition = PhysicsTools.RandomPointInBounds(boxCollider.bounds);
                Instantiate(prefab, initialPosition, Quaternion.identity);
            }
        }


    }

}