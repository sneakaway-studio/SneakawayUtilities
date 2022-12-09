using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *	Move (game object | camera | etc.) in <direction> at <speed> along the <target> looking at point
 */

namespace SneakawayUtilities
{
    public class LerpAlongBounds : MonoBehaviour
    {
        [Tooltip("Transform to move around")]
        public Collider targetCollider;

        [Tooltip("Points to follow")]
        public Vector3[] points;

        [Tooltip("Transform to look at")]
        public Transform targetLookAt;

        [Tooltip("Should the GO look at the target?")]
        public bool lookAtTarget = true;

        [Tooltip("Indexer to move through points")]
        public TimeTools.Indexer indexer;

        [Tooltip("Time")]
        public float t;
        [Tooltip("Step interval")]
        public float step = .01f;

        [Tooltip("Movement axes")]
        public Vector3 axis = Vector3.one;

        [Tooltip("Movement speed")]
        public float speed = 10.0f;

        public enum OnPointReached
        {
            Bounce,
            RotateAround
        }
        public OnPointReached onPointReached;


        void Start()
        {
            // get points of bounds
            points = PhysicsTools.GetBoundsFarPoints(targetCollider.bounds, new Vector3(1, 0, 0));
            Debug.Log(points);

            // create indexer to count through points
            indexer = new TimeTools.Indexer(points.Length);

            // make the camera look to it
            if (lookAtTarget) transform.LookAt(targetLookAt.position);
        }

        private void Update()
        {
            Debug.DrawRay(points[indexer.current], points[indexer.next], Color.red);
        }
        void FixedUpdate() => Move();

        void Move()
        {

            t += step;
            transform.position = Vector3.Lerp(points[indexer.current], points[indexer.next], t);

            if (t > 1)
            {
                if (onPointReached == OnPointReached.Bounce)
                {
                    // make the camera look to it
                    if (lookAtTarget) transform.LookAt(targetLookAt.position);
                }
                else if (onPointReached == OnPointReached.RotateAround)
                {

                }
                t = 0;
                indexer.NextIndex();
            }
        }




    }
}
