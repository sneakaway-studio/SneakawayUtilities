using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/**
 *  Set this, or another game object, or even a component! active or inactive on awake
 *  - good for prefabs, gizmos, markers, etc. left out, or hiding "pop up" UIs when not in use.
 */

namespace SneakawayUtilities
{
    public class SetActiveOnAwake : MonoBehaviour
    {
        [Tooltip("If neither obj or component is set then will default to this gameObject")]
        public GameObject obj;

        [Tooltip("If neither obj or component is set then will default to this gameObject")]
        public Component component;

        [Tooltip("Set true to become active, false to hide")]
        public bool setActive;

        [Tooltip("Set true to become active, false to hide")]
        public string prefabName;

        private void Awake()
        {
            // if obj is not set default to this gameObject
            if (obj == null && component == null) obj = gameObject;
            //Debug.Log("SetActiveOnAwake [1] " + obj.name);

            // for using to hide left out prefabs (not sure this is necessary thanks to the above)
            if (prefabName != "" && obj.name != prefabName) return;
            //Debug.Log("SetActiveOnAwake [2] " + obj.name);

            // set active or not
            obj.SetActive(setActive);
        }
        // to disable this componetn in inspector
        private void Start() { }
    }
}
