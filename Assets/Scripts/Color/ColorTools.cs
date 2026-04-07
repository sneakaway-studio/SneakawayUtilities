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



        /// <summary>Return an RGB Color</summary>
        /// https://docs.unity3d.com/ScriptReference/ColorUtility.TryParseHtmlString.html
        public static Color GetColorFromHex(string hex = "FF0000")
        {
            // "#" is required or it will treat the string as a "color name"
            if (hex[0] != '#') hex = "#" + hex;
            Color color = Color.red;
            ColorUtility.TryParseHtmlString(hex, out color);
            return color;
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





        /// <summary>Creates color with corrected brightness. Reference https://stackoverflow.com/a/12598573/441878 </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1.
        /// Negative values produce darker colors.</param>
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.r;
            float green = (float)color.g;
            float blue = (float)color.b;
            float alpha = (float)color.a;
            // Debug.Log($"1- R {red} B {green} B {blue}");

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (1 - red) * correctionFactor + red;
                green = (1 - green) * correctionFactor + green;
                blue = (1 - blue) * correctionFactor + blue;
            }
            // Debug.Log($"2- R {red} B {green} B {blue}");

            return new Color(red, green, blue, alpha);
        }


    }
}
