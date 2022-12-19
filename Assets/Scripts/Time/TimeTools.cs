using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SneakawayUtilities
{
    public static class TimeTools
    {

        /////////////////////////////////
        ///////////// TYPES /////////////
        /////////////////////////////////

        /// <summary>
        /// "Pagination" struct with prev/current/next
        /// </summary>
        [System.Serializable]
        public struct Indexer
        {
            public int prev;
            public int current;
            public int next;
            public int nextnext; // OMG
            public int count;
            // set default values
            public Indexer(int _count)
            {
                count = _count; // e.g. count = 10 = 10,0,1
                prev = count - 1;
                current = 0;
                next = (count > 0) ? 1 : 0;
                nextnext = (count > 1) ? 2 : 0;
            }
            // advance to next | prev index, update values
            public void NextIndex() => UpdateIndexes(next);
            public void PrevIndex() => UpdateIndexes(prev);

            // call after current has been set, to set / check values
            public void UpdateIndexes(int _current)
            {
                current = _current; // set current 
                if (current >= count) current = 0; // if should loop

                next = current + 1; // set next
                if (next >= count) next = 0; // if should loop

                nextnext = next + 1; // set nextnext
                if (nextnext >= count) nextnext = 0; // if should loop

                prev = current - 1; // set prev
                if (prev < 0) prev = count - 1; // if should loop
            }
        }


        public static string ToStringDateTime24Hour(this DateTime dt)
        {
            return dt.ToString(@"HH\:mm\:ss");
        }
        public static string ToStringTime24(this DateTime dt)
        {
            return dt.ToString(@"HH\:mm\:ss");
        }
        public static string ToStringTime24(this TimeSpan dt)
        {
            return dt.ToString(@"HH\:mm\:ss");
        }

    }
}
