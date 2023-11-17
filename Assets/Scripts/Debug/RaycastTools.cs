using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SneakawayUtilities
{
    public static class RaycastTools
    {


        /// <summary>
        /// Draw ray between two points
        /// </summary>
        public static void DrawRayBetweenPoints(Vector3 p1, Vector3 p2)
        {
            Debug.DrawRay(p1, (p2 - p1), Color.yellow);
        }


        /// <summary>
        /// List all gameobjects under pointer
        /// Reference: https://forum.unity.com/threads/how-to-raycast-onto-a-unity-canvas-ui-image.855259/#post-8180516
        /// Usage: RaycastTools.GameObjectsUnderPointer(Input.mousePosition);
        /// </summary>
        public static List<GameObject> GameObjectsUnderPointer(Vector2 screenPos)
        {
            var hitObject = GameObjectsRaycastIntersect(ScreenPosToPointerData(screenPos));
            if (hitObject == null)
                return new List<GameObject>();
            return hitObject;
        }
        public static List<GameObject> GameObjectsRaycastIntersect(PointerEventData pointerData)
        {
            // get all items under cursor
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            // return as list
            List<GameObject> goList = new List<GameObject>();
            foreach (var result in results)
            {
                goList.Add(result.gameObject);
            }
            return goList;
        }
        static PointerEventData ScreenPosToPointerData(Vector2 screenPos)
            => new(EventSystem.current) { position = screenPos };




    }
}







