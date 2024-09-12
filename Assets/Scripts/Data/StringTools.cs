using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

namespace SneakawayUtilities
{
	public static class StringTools
	{

		/////////////////////////////////
		///////////// TYPES /////////////
		/////////////////////////////////


		/// <summary>
		/// Log the length of a string
		/// </summary>
		/// <param name="str"></param>
		public static void LogLength(this string str)
		{
			Debug.Log($"'{str}' (string) contains {str.Length} characters");
		}


		/////////////////////////////////
		//////////// FORMAT /////////////
		/////////////////////////////////

		/// <summary>
		/// Format zeros for an integer
		/// </summary>
		/// <param name="num"></param>
		/// <param name="digits"></param>
		/// <returns></returns>
		public static string FormatZeros(this int num, string digits = "00")
		{
			return num.ToString(digits);
		}
		public static string FormatZeros(this float num, string digits = "00")
		{
			return num.ToString(digits);
		}


		/////////////////////////////////
		/////////// CONVERT /////////////
		/////////////////////////////////

		/// <summary>
		/// Split text by line breaks to a list
		/// </summary>
		/// <param name="stringToSplit"></param>
		/// <returns></returns>
		public static List<string> LinesToList(string stringToSplit)
		{
			return stringToSplit.Trim()?.Split('\n').Select(txt => txt.Trim()).ToList();
		}
		public static string SplitToLines(string stringToSplit, int maximumLineLength)
		{
			return Regex.Replace(stringToSplit, @"(.{1," + maximumLineLength + @"})(?:\s|$)", "$1\n");
		}


		/// <summary>
		/// Convert a "(0,0,0)" string to Vector3
		/// </summary>
		public static Vector3 StringToVector3(string str)
		{
			// remove parentheses
			str = str.Replace("(", "").Replace(")", "");
			// split, cast, return
			string[] arr = str.Split(',');
			Vector3 result = new Vector3();
			if (float.TryParse(arr[0], out float x) &&
				float.TryParse(arr[0], out float y) &&
				float.TryParse(arr[0], out float z))
			{
				result = new Vector3(x, y, z);
			}
			return result;
		}


	}
}