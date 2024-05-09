using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

// Added Base Class on May 9, 2024 (HairGuitar) - may need adjustment for previous uses (CTS-VIZ)

namespace SneakawayUtilities
{
    public class ColorLerp : ColorLerpBase
    {
        // ColorLerpBase fields here ...


        [Header("ColorLerp")]

        [Tooltip("Material for this game object")]
        public Material material;

        // overriding so to get references
         protected override void Awake()
        {
            material = GetComponent<Renderer>().material;
            base.Awake();
        }

        protected override void ChangeColor() 
        {
            // change local color
            LerpMaterialColor();
            // set component color
            material.color = color;
        }

        void LerpMaterialColor()
        {
            // old method? uses coroutines
            // indexer.NextIndex();
            // SneakawayUtilities.ColorTools.ChangeMaterialColor(this, material, colors[indexer.current].color, colors[indexer.next].color, colors[indexer.current].duration, false);



            // update time    
            time += Time.deltaTime / colors[indexer.current].duration;

            // change color
            color = Color.Lerp(colors[indexer.current].color, colors[indexer.next].color, time);

        }

    }
}
