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
            points[0] = bounds.min;
            points[1] = bounds.max;

            // Note that this will create a world space bounding box:
            // if your collider is at an odd angle, this will give you
            // a rather large box around it.If you need a local space
            // bounding box(which can be combined with the Transform
            // to put it in world space), replace the first two
            // lines with the following, which will get you a box that
            // matches the BoxCollider gizmo after being transformed:
            // https://answers.unity.com/questions/29797/how-to-get-8-vertices-from-bounds-properties.html
            points[0] = bounds.center - (bounds.size / 2f);
            points[1] = bounds.center + (bounds.size / 2f);

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



    }
}
