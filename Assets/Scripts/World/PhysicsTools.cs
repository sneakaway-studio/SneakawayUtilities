using UnityEngine;
using System.Collections;
using SneakawayUtilities;

namespace SneakawayUtilities
{
    public static class PhysicsTools
    {

        /////////////////////////////////
        /////////// COLLISION ///////////
        /////////////////////////////////


        public static bool CheckCollision(Collision2D collision, string nameToCompare)
        {
            return collision.gameObject.layer == LayerMask.NameToLayer(nameToCompare);
        }

        public static void SetGameObjectLayerMask(GameObject obj, string layerMaskName)
        {
            // convert layermask name to layer integer
            int LayerIgnoreRaycast = LayerMask.NameToLayer(layerMaskName);
            // assign to layer
            obj.layer = LayerIgnoreRaycast;
            //Debug.Log("Current layer: " + obj.layer);
        }


        /////////////////////////////////
        /////////// BOUNDS //////////////
        /////////////////////////////////

        /// <summary>Return random Vector3 position inside bounds</summary>
        /// <param name="bounds"></param>
        /// <returns>True</returns>
        public static Vector3 RandomPointInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        /// <summary>
        /// Return true if point is inside worldcontainer collider
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsPointWithinCollider(BoxCollider collider, Vector3 point)
        {
            return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
        }

        ///       .3------Max
        ///     .' |    .'|
        ///    2---+--7'  |
        ///    |   |  |   |
        ///    |  .4--+---5
        ///    |.'    | .'
        ///  Min------6'
        ///
        /// <summary>Get the 8 vertices of a bounds</summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Vector3[] GetBoundsCorners(Bounds bounds)
        {
            Vector3[] points = new Vector3[8];
            points[0] = GetBoundsLocalMin(bounds);
            points[1] = GetBoundsLocalMax(bounds);
            // west
            points[2] = new Vector3(points[0].x, points[1].y, points[0].z);
            points[3] = new Vector3(points[0].x, points[1].y, points[1].z);
            points[4] = new Vector3(points[0].x, points[0].y, points[1].z);
            // east
            points[5] = new Vector3(points[1].x, points[0].y, points[1].z);
            points[6] = new Vector3(points[1].x, points[0].y, points[0].z);
            points[7] = new Vector3(points[1].x, points[1].y, points[0].z);
            return points;
        }
        // Using bounds.min || bounds.max creates a world space bounding box.
        // A collider at an odd angle will return a large box around the extents.
        // The below gets a local space bounding box (compare with a Gizmo if needed)
        // https://answers.unity.com/questions/29797/how-to-get-8-vertices-from-bounds-properties.html
        public static Vector3 GetBoundsLocalMin(Bounds bounds)
        {
            //return bounds.min;
            return bounds.center - (bounds.size / 2f);
        }
        public static Vector3 GetBoundsLocalMax(Bounds bounds)
        {
            //return bounds.max;
            return bounds.center + (bounds.size / 2f);
        }
        /// <summary>
        /// Return opposite points across a bounds, effectively slicing it in half
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Vector3[] GetBoundsFarPoints(Bounds bounds, Vector3 axis)
        {
            Vector3 min = GetBoundsLocalMin(bounds);
            Vector3 max = GetBoundsLocalMax(bounds);
            //Debug.Log("GetBoundsFarPoints() min" + min);
            //Debug.Log("GetBoundsFarPoints() max" + max);
            Vector3[] points = new Vector3[2];
            if (axis == new Vector3(1, 0, 0))
            {
                points[0] = new Vector3(min.x, 0, 0);
                points[1] = new Vector3(max.x, 0, 0);
            }
            else if (axis == new Vector3(0, 1, 0))
            {
                points[0] = new Vector3(0, min.y, 0);
                points[1] = new Vector3(0, max.y, 0);
            }
            else if (axis == new Vector3(0, 0, 1))
            {
                points[0] = new Vector3(0, 0, min.z);
                points[1] = new Vector3(0, 0, max.z);
            }
            //Debug.Log("GetBoundsFarPoints() " + points[0].ToString());
            //Debug.Log("GetBoundsFarPoints() " + points[1].ToString());
            return points;
        }


    }
}
