﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SneakawayUtilities;
// using UnityEngine.InputSystem;

namespace SneakawayUtilities
{
    public static class SpriteTools
    {
        static bool DEBUG = false;



        public static Sprite[] Shuffle(Sprite[] arr)
        {
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int t = 0; t < arr.Length; t++)
            {
                Sprite tmp = arr[t];
                int r = UnityEngine.Random.Range(t, arr.Length);
                arr[t] = arr[r];
                arr[r] = tmp;
            }
            return arr;
        }




        /**************************************************************************/
        /************************* SPRITE SELECTION *******************************/
        /**************************************************************************/


        /// <summary>
        /// Return the topmost (highest sort order) SpriteRenderer from ray (of type T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="layerMask"></param>
        /// <returns></returns>
        public static SpriteRenderer ReturnHighestSpriteRenderer<T>(LayerMask layerMask)
        {
            if (DEBUG) Debug.Log("ReturnHighestSpriteRenderer() of type " + typeof(T));

            // get all sprite renderers under mouse
            List<SpriteRenderer> sortedSpriteRenderers = ReturnSortedSpriteRenderersFromRay(layerMask);

            // exit early if none found
            if (sortedSpriteRenderers.Count <= 0) return new SpriteRenderer();

            // otherwise assume the first is the correct one
            return sortedSpriteRenderers[0];
        }


        public static SpriteRenderer ReturnHighestSpriteRendererForDrag<T>(LayerMask layerMask)
        {
            if (DEBUG) Debug.Log("ReturnHighestSpriteRendererForDrag()");

            // get all sprite renderers under mouse
            List<SpriteRenderer> sortedSpriteRenderers = ReturnSortedSpriteRenderersFromRay(layerMask);

            // to store the highest object we find
            SpriteRenderer highestSpriteRenderer = null;

            // exit early
            if (sortedSpriteRenderers.Count <= 0)
            {
                if (DEBUG) Debug.LogWarning("sortedSpriteRenderers.Count == 0");
                return highestSpriteRenderer;
            }

            // start at the lowest possible sort order
            int highestSortingOrder = -int.MaxValue;

            // loop through all sprites found
            for (int i = 0; i < sortedSpriteRenderers.Count; i++)
            {
                T foundObjectTemp = sortedSpriteRenderers[i].transform.GetComponent<T>();

                // continue if GO doesn't have a SpriteRenderer and DragObject script
                if (sortedSpriteRenderers[i] == null || foundObjectTemp == null) continue;

                // ensure this is the highest by comparing to current highest
                if (sortedSpriteRenderers[i].sortingOrder > highestSortingOrder)
                {
                    // update highest
                    highestSortingOrder = sortedSpriteRenderers[i].sortingOrder;
                    // store reference
                    highestSpriteRenderer = sortedSpriteRenderers[i];
                }

                if (DEBUG) Debug.Log($"ReturnHighestSpriteRendererForDrag() - {i}. {sortedSpriteRenderers[i].sortingOrder} " +
                    $"({sortedSpriteRenderers[i].sortingLayerName}) - {sortedSpriteRenderers[i].gameObject.name}");
            }
            // this will definitely be the highest
            return highestSpriteRenderer;
        }



        /// <summary>
        /// Return List of SpriteRenderes sorted by the highest sort order
        /// <a href="https://forum.unity.com/threads/c-object-on-top-with-highest-sortingorder-is-not-selected-first.244627/#post-3304532">ref</a>
        /// </summary>
        /// <param name="layerMask"></param>
        /// <returns></returns>        
        public static List<SpriteRenderer> ReturnSortedSpriteRenderersFromRay(LayerMask layerMask)
        {
            //Debug.Log("ReturnSortedSpriteRenderersFromRay()");

            // create a ray going from camera through a screen point
            Ray ray = Camera.main.ScreenPointToRay(ReturnPointerPosition());

            ShowRay(ray, Color.red);

            // cast the 3D ray into the scene, returning ALL the Colliders along the ray
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity, layerMask);

            // exit early if we don't hit something
            if (hits.Length <= 0)
            {
                //Debug.LogWarning("hits.Length == 0");
                return new List<SpriteRenderer>();
            }

            // store the objects we find
            List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

            // loop through all the hit objects
            for (int i = 0; i < hits.Length; i++)
            {
                SpriteRenderer hitSpriteRenderer = hits[i].transform.GetComponent<SpriteRenderer>();

                // break if GO doesn't have a SpriteRenderer
                if (hitSpriteRenderer == null)
                {
                    //Debug.LogWarning("No spriteRenderer");
                    break;
                }

                // store reference
                spriteRenderers.Add(hitSpriteRenderer);
            }

            return SortSpriteRendererList(spriteRenderers, "DESC");
        }



        public static Collider2D ReturnTopColliderFromRay(LayerMask layerMask)
        {
            Collider2D collider = null; // default will be returned if none found          
            RaycastHit2D hit = GetHitCollider(layerMask); // check for hit           
            if (hit && hit.collider) collider = hit.collider;  // return appropriate references        
            return collider;
        }
        public static GameObject ReturnTopGameObjectFromRay(LayerMask layerMask)
        {
            GameObject obj = null;
            RaycastHit2D hit = GetHitCollider(layerMask);
            if (hit && hit.collider) obj = hit.collider.gameObject;
            return obj;
        }





        /**************************************************************************/
        /************************* HELPER FUNCTIONS *******************************/
        /**************************************************************************/

        /// <summary>Check for a hit object using raycast. Used by several above</summary>
        /// <returns>RaycastHit2D</returns>
        static RaycastHit2D GetHitCollider(LayerMask layerMask)
        {
            // create a ray going from camera through a screen point
            Ray ray = Camera.main.ScreenPointToRay(ReturnPointerPosition());
            // cast the 3D ray into the scene, returning ALL the Colliders along the ray
            return Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);
        }

        /// <summary>Return current pointer (mouse or finger) position</summary>
        /// <returns>Vector2</returns>
        public static Vector2 ReturnPointerPosition()
        {
        //     // note: all of these work on desktop and remote
        //     if (Input.touchCount > 0)
        //         Debug.Log($"Input.GetTouch(0).position = {Input.GetTouch(0).position}");
        //     Debug.Log($"Input.mousePosition = {Input.mousePosition}");
        //     Debug.Log($"Mouse.current.position.ReadValue() = {Mouse.current.position.ReadValue()}");
        //     Debug.Log($"Pointer.current.position.ReadValue() = {Pointer.current.position.ReadValue()}");
            return Input.mousePosition;
        }

        /// <summary>Return list of sprite renderers, sorted by order</summary>
        /// <returns>List<SpriteRenderer></returns>
        public static List<SpriteRenderer> SortSpriteRendererList(List<SpriteRenderer> list, string order = "ASC")
        {
            //Debug.Log("SortSpriteRendererList() [1] #################################");
            //LogList(spriteRenderers);

            if (order == "ASC")
                list.Sort((x, y) => x.sortingOrder.CompareTo(y.sortingOrder));
            else
                list.Sort((x, y) => y.sortingOrder.CompareTo(x.sortingOrder));

            //Debug.Log("SortSpriteRendererList() [2] #################################");
            //LogList(spriteRenderers);

            return list;
        }





        /**************************************************************************/
        /*************************** DEBUGGING ************************************/
        /**************************************************************************/

        public static void GetRayAndShow(Color color)
        {
            // create a ray going from camera through a screen point
            Ray ray = Camera.main.ScreenPointToRay(ReturnPointerPosition());
            ShowRay(ray, color);
        }

        public static void ShowRay(Ray ray, Color color)
        {
            Debug.DrawRay(ray.origin, ray.direction * 100000000, color, 3);
        }

        public static void LogArray(SpriteRenderer[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Debug.Log($"LogArray() - {i} - {arr[i].sortingLayerName} ({arr[i].sortingOrder}) - {arr[i].name}");
            }
        }
        public static void LogList(List<SpriteRenderer> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (DEBUG) Debug.Log($"LogList() - {i} - {list[i].sortingOrder} ({list[i].sortingLayerName}) - {list[i].name}");
            }
        }


    }
}
