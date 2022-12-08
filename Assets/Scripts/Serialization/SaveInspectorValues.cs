using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/**
 *  Move old serialized values to new properties
 *  - Add everything below (except the class) and 
 */


// UPDATE: Maybe better method?
// https://www.youtube.com/watch?v=Nl2imdYPm38&ab_channel=DanPos-GameDevTutorials%21
// https://docs.unity3d.com/ScriptReference/Serialization.FormerlySerializedAsAttribute.html
// 1. Add this, keeping old var in: [FormerlySerializedAs("fieldName")] newFieldName = new List<Field>();
// 2. Switch to the Editor (to let it serialize)
// Now you can remove the old one

namespace SneakawayUtilities
{
    public class SaveInspectorValues : MonoBehaviour
    {

        public int oldProp;
        public int prop;

        void OnValidate()
        {
            prop = oldProp;

            // can also be used to iterate over lists in scriptable objects
            // public List<VizFiles> vizFiles = new List<VizFiles>();
            // foreach (var f in vizFiles)
            // {
            // 	f.prop = f.oldProp;
            // }
        }


    }
}
