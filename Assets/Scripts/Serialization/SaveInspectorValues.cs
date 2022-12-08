using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;
using UnityEngine.Serialization;

/**
 *  Move old serialized values to new properties
 */

namespace SneakawayUtilities
{
    public class SaveInspectorValues : MonoBehaviour
    {

        // METHOD 1 -> FormerlySerializedAs
        // https://www.youtube.com/watch?v=Nl2imdYPm38&ab_channel=DanPos-GameDevTutorials%21
        // https://docs.unity3d.com/ScriptReference/Serialization.FormerlySerializedAsAttribute.html

        public List<Object> oldProp = new List<Object>();
        [FormerlySerializedAs("oldProp")] public List<Object> newFieldName = new List<Object>();

        // 1. Add FormerlySerializedAs attribute
        // 2. Switch to the Editor (to let it serialize)
        // 3. Now you can remove the old field




        // METHOD 2 -> OnValidate() is called when script is compiled

        void OnValidate()
        {
            // can also be used to iterate over lists in scriptable objects
            // public List<VizFiles> vizFiles = new List<VizFiles>();
            // foreach (var f in vizFiles)
            // {
            // 	f.prop = f.oldProp;
            // }
        }


    }
}
