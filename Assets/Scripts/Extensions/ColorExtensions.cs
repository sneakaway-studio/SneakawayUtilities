using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SneakawayUtilities
{
    public static class ColorExtensions
    {

        /////////////////////////////////
        ///////////// TYPES /////////////
        /////////////////////////////////



        /////////////////////////////////
        ///////// RANDOM COLORS /////////
        /////////////////////////////////

        /// <summary>Return a random color</summary>
        public static Color RandomColor()
        {
            return new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        }

        /////////////////////////////////
        ///////// COLOR LERPING /////////
        /////////////////////////////////



        public static IEnumerator ChangeMaterialColor(Material material, Color startColor, Color endColor, float duration)
        {
            float t = 0;

            while (t < duration)
            {
                t += Time.deltaTime;
                material.color = Color.Lerp(startColor, endColor, t / duration);
                yield return null;
            }
        }
        public static IEnumerator ChangeLight2DColor(Light2D light, Color startColor, Color endColor, float duration)
        {
            float t = 0;

            while (t < duration)
            {
                t += Time.deltaTime;
                light.color = Color.Lerp(startColor, endColor, t / duration);
                yield return null;
            }
        }


        // public static void CallWithDelay(this MonoBehaviour mono, Action method, float delay)
        //    => mono.StartCoroutine(CallWithDelayRoutine(method, delay));
        //
        // public static IEnumerator CallWithDelayRoutine(Action method, float delay)
        // {
        //    yield return new WaitForSeconds(delay);
        //    method();
        // }


    }
}
