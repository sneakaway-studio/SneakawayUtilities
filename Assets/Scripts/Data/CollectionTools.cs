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

        /// <summary>Remove (not destroy) all in items from any List<T></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> RemoveAllFromList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list.RemoveAt(i);
            }
            return list;
        }






    }
}
