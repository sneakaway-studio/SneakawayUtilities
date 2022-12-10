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
        public string componentName;

        [Tooltip("Set true to become active, false to hide")]
        public string prefabName;

        [Tooltip("Set true to become active, false to hide")]
        public bool setActive;

        private void Awake()
        {
            // if obj is not set default to this gameObject
            if (obj == null && componentName == "") obj = gameObject;

            // hide left out prefabs (not sure this is necessary thanks to the above)
            if (prefabName != "" && obj.name != prefabName) return;

            if (obj != null)
            {
                obj.SetActive(setActive);
            }
            else
            {
                switch (componentName)
                {
                    case "SpriteRenderer":
                        GetComponent<SpriteRenderer>().enabled = false;
                        break;
                    case "MeshRenderer":
                        GetComponent<MeshRenderer>().enabled = false;
                        break;
                }
            }
        }
        // to disable this component in inspector
        private void Start() { }
    }
}
