using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SneakawayUtilities
{
    public static class StringTools
    {

        /// <summary>
        /// Log the length of a string
        /// </summary>
        /// <param name="str"></param>
        public static void LogLength(this string str)
        {
            Debug.Log($"'{str}' (string) contains {str.Length} characters");
        }


        public static string FormatZeros(this int num, string digits = "00")
        {
            return num.ToString(digits);
        }
        public static string FormatZeros(this float num, string digits = "00")
        {
            return num.ToString(digits);
        }


    }
}