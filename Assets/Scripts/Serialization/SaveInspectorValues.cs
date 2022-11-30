using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

/**
 *  Move old serialized values to new properties
 *  - Add everything below (except the class) and switch to the Editor (just once)
 */

namespace SneakawayUtilities
{
	// [ExecuteInEditMode]
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
