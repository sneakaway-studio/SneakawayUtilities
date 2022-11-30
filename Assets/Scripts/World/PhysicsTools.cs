using UnityEngine;
using System.Collections;
using SneakawayUtilities;

namespace SneakawayUtilities
{
    public static class PhysicsTools
    {




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



    }
}
