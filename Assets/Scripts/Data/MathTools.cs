using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SneakawayUtilities
{
    public static class MathTools
    {

        /////////////////////////////////
        ///////////// TYPES /////////////
        /////////////////////////////////

        /// <summary>
        /// Range struct with min/max
        /// </summary>
        [System.Serializable]
        public struct Range
        {
            public float min;
            public float max;
            public Range(float _min, float _max)
            {
                min = _min;
                max = _max;
            }
        }



        /////////////////////////////////
        //////// RANDOM CHANCE //////////
        /////////////////////////////////

        /// <summary>
        /// Returns true if percent is > random 0-1
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static bool RandomChance(float percent)
        {
            if (RandomFloat() < percent) return true;
            return false;
        }

        public static float RandomFloat()
        {
            return Random.Range(0f, 1f);
        }


        /////////////////////////////////
        ////////// RANDOM INT ///////////
        /////////////////////////////////

        /// <summary>Return a random int</summary>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximium</param>
        /// <returns>int</returns>
        public static int RandomInt(this int min, int max)
        {
            // they are both zero
            if (min == 0 && max == 0) return 0;
            // they are the same, just return one
            if (min == max) return min;
            // else generate random and return
            int r = (int)UnityEngine.Random.Range(min, max);
            //Debug.Log(r);
            return r;
        }
        /// <summary>Return a random int (from floats)</summary>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximium</param>
        /// <returns>int</returns>
        public static int RandomInt(this float min, float max)
        {
            // they are both zero
            if (min == 0 && max == 0) return 0;
            // they are the same, just return one
            if (min == max) return (int)min;
            // else generate random and return
            int r = (int)UnityEngine.Random.Range(min, max);
            //Debug.Log(r);
            return r;
        }

        /////////////////////////////////
        ///////// RANDOM FLOAT //////////
        /////////////////////////////////

        /// <summary>Return a random float within a Range</summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static float RandomFloatFromRange(this Range range)
        {
            // https://docs.unity3d.com/ScriptReference/Random.Range.html
            return UnityEngine.Random.Range(range.min, range.max);
        }
        public static float RandomFloatFromVector2(this Vector2 range)
        {
            if (range.magnitude < 0.01)
                return 0;
            float r = Random.Range(range.x, range.y);
            //Debug.Log(r);
            return r;
        }

        /////////////////////////////////
        //////// RANDOM VECTOR3 /////////
        /////////////////////////////////

        /// <summary>
        /// Return a Vector3 with random X,Y,Z from Range
        /// </summary>
        /// <param name="rangeX"></param>
        /// <param name="rangeY"></param>
        /// <param name="rangeZ"></param>
        /// <returns></returns>
        public static Vector3 RandomVector3FromRange(
            this Range rangeX, Range rangeY, Range rangeZ)
        {
            return new Vector3(
                Random.Range(rangeX.min, rangeX.max),
                Random.Range(rangeY.min, rangeY.max),
                Random.Range(rangeZ.min, rangeZ.max)
            );
        }
        public static Vector3 RandomVector3FromRange(
            this Range range)
        {
            return new Vector3(
                Random.Range(range.min, range.max),
                Random.Range(range.min, range.max),
                Random.Range(range.min, range.max)
            );
        }


        /////////////////////////////////
        /////// RANDOM QUATERNION ///////
        /////////////////////////////////

        /// <summary>
        /// Return a random quaternion with angles between 0-360 (see tests for notes)
        /// </summary>
        /// <returns></returns>
        public static Quaternion RandomQuaternion()
        {
            return Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        }
        public static Quaternion RandomQuaternion(Range xRange, Range yRange, Range zRange)
        {
            // another valid use??
            //return Quaternion.Euler(Random.Range(xRange.min, xRange.max), Random.Range(yRange.min, yRange.max), Random.Range(zRange.min, zRange.max));

            Quaternion currentRotation = new Quaternion();

            // change Vector3 > Quanternion.eulerAngle format
            currentRotation.eulerAngles = new Vector3(
                   Random.Range(xRange.min, xRange.max),
                   Random.Range(yRange.min, yRange.max),
                   Random.Range(zRange.min, zRange.max)
               );
            //Debug.Log(currentRotation.eulerAngles);

            // return and apply the Quaternion.eulerAngles to the gameObject.transform.rotation
            return currentRotation;
        }



        /////////////////////////////////
        //////// RANDOM LIST<T> /////////
        /////////////////////////////////

        /// <summary>Return a random index from any List<T></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int RandomListIndex<T>(this List<T> list)
        {
            return (int)Random.Range(0, list.Count);
        }

        /// <summary>Return a random index from any List</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomListValue<T>(this List<T> list)
        {
            return list[list.RandomListIndex()];
        }






    }
}
