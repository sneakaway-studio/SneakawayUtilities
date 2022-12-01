using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SneakawayUtilities
{
    public static class ColorTools
    {

        /////////////////////////////////
        ///////////// TYPES /////////////
        /////////////////////////////////

        [System.Serializable]
        public class ColorTransition
        {
            public Color color;
            public float duration;
        }


        /////////////////////////////////
        ///////// RANDOM COLORS /////////
        /////////////////////////////////

        /// <summary>Return a random color</summary>
        public static Color RandomColor()
        {
            return new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f)
            );
        }



        /////////////////////////////////
        /////////// EQUALITY ////////////
        /////////////////////////////////

        public static bool AreEqual(Color color1, Color color2)
        {
            //Debug.Log((int)(color1.r * 1000) + "," + (int)(color2.r * 1000));
            //Debug.Log((int)(color1.g * 1000) + "," + (int)(color2.g * 1000));
            //Debug.Log((int)(color1.b * 1000) + "," + (int)(color2.b * 1000));
            if (Mathf.Approximately(color1.r * 1000, color2.r * 1000) &&
                Mathf.Approximately(color1.g * 1000, color2.g * 1000) &&
                Mathf.Approximately(color1.b * 1000, color2.b * 1000)) return true;
            return false;
        }



        /////////////////////////////////
        ///////// COLOR LERPING /////////
        /////////////////////////////////

        /// <summary>
        /// Change the color of a material over duration (in seconds). 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="material"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <param name="duration">In seconds</param>
        /// <param name="pingPong">True will make it ping pong back and forth</param>
        /// <param name="callback"></param>
        public static void ChangeMaterialColor(
            MonoBehaviour instance,
            Material material,
            Color color1,
            Color color2,
            float duration,
            bool pingPong = false,
            Action callback = null)
        => instance.StartCoroutine(ChangeMaterialColorCo(instance, material, color1, color2, duration, pingPong, callback));

        public static IEnumerator ChangeMaterialColorCo(MonoBehaviour instance, Material material,
            Color color1, Color color2, float duration, bool pingPong, Action callback)
        {
            float t = 0;
            // start at zero, end at 1
            while (t <= 1.01)
            {
                material.color = Color.Lerp(color1, color2, t);
                t += Time.deltaTime / duration;
                yield return null;
            }
            //Debug.Log("ChangeMaterialColorCo() finished");

            if (pingPong != false) ChangeMaterialColor(instance, material, color2, color1, duration, pingPong);
            else if (callback != null) callback();
        }






        public static void ChangeInstanceColor(
            MonoBehaviour instance,
            ColorInstance colorInstance,
            Color color1,
            Color color2,
            float duration,
            bool pingPong = false,
            Action callback = null)
        => instance.StartCoroutine(ChangeColorCo(instance, colorInstance, color1, color2, duration, pingPong, callback));

        public static IEnumerator ChangeColorCo(MonoBehaviour instance, ColorInstance colorInstance,
            Color color1, Color color2, float duration, bool pingPong, Action callback)
        {
            float t = 0;
            // start at zero, end at 1
            while (t <= 1.01)
            {
                colorInstance.color = Color.Lerp(color1, color2, t);
                t += Time.deltaTime / duration;
                yield return null;
            }
            //Debug.Log("ChangeMaterialColorCo() finished");

            if (pingPong != false) ChangeInstanceColor(instance, colorInstance, color2, color1, duration, pingPong);
            else if (callback != null) callback();
        }



    }
}
