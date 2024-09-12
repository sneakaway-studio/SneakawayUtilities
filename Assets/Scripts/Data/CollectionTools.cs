using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SneakawayUtilities
{
	public static class CollectionTools
	{




		/////////////////////////////////
		//////////// LIST<T> ////////////
		/////////////////////////////////

		/// <summary>Find index of list<T> item where field = val (good for data organized by slug)</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns>-1 if not found</returns>
		public static int FindListIndexByPropertyValue<T>(List<T> list, string field, string val)
		{
			int _index = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (Equals(list[i].GetType().GetField(field).GetValue(list[i]), val))
				{
					return i;
				}
			}
			return _index;


			//     return list.FindIndex(p =>
			//         Equals(p.GetType().GetProperty(field).GetValue(list), val));
		}

		/// <summary>Remove (not destroy) all in items from any List<T></summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static List<T> RemoveAllFromList<T>(List<T> list)
		{
			int i = list.Count - 1;
			while (i >= 0)
				list.RemoveAt(i--);
			return list;
		}



		/// <summary>
		/// Find a transform in a child (used non-static w/o transform parameter)
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		public static Transform FindChildTransformSafe(Transform transform, string str)
		{
			try
			{
				Transform t = transform.Find(str);
				if (t != null) return t;
			}
			catch (MissingReferenceException e)
			{
				Debug.Log(e.Message);
			}
			return transform;
		}



		public static void HideAllInList(List<GameObject> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].gameObject.SetActive(false);
			}
		}



	}
}
