using UnityEngine;
using System.Collections;

/**
 *	Rotate (game object | camera | etc.) in <direction> at <speed> around the <target> looking at point | <target>
 */

namespace SneakawayUtilities
{
    public class RotateAround : MonoBehaviour
    {
        [Tooltip("Transform around which this GO will rotate around")]
        public Transform target;

        [Tooltip("Rotation axis (default: Y)")]
        public Vector3 axis = Vector3.up;

        [Tooltip("Rotatin speed")]
        public float speed = 10.0f;

        [Tooltip("Should the GO look at the target?")]
        public bool lookAtTarget = true;


        void Start()
        {
            if (lookAtTarget) transform.LookAt(target.position);
        }

        void FixedUpdate() => RotateObject();

        void RotateObject()
        {
            // rotates around target.position, about axis * speed modifier
            // https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html
            transform.RotateAround(target.position, axis, Time.deltaTime * speed);
        }


    }
}
