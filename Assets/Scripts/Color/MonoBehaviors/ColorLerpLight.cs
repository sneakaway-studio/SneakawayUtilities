using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

// Added Base Class on May 9, 2024 (HairGuitar) - may need adjustment for previous uses (CTS-VIZ)

namespace SneakawayUtilities
{
    public class ColorLerpLight : ColorLerpBase
    {
        // ColorLerpBase fields here ...


        [Header("ColorLerpLight")]

        [Tooltip("Light on this game object")]
        public ColorInstance colorInstance;

        public Light lightComponent;

        // overriding so to get references
        protected override void Awake()
        {
            if (colorInstance == null) colorInstance = GetComponent<ColorInstance>();
            if (lightComponent == null) lightComponent = GetComponent<Light>();
            base.Awake();
        }

        protected override void ChangeColor() 
        {
            // change local color
            LerpLightColor();
            // set component color
            lightComponent.color = color;
        }

        void LerpLightColor()
        {
            indexer.NextIndex();
            ColorTools.ChangeInstanceColor(this, colorInstance, colors[indexer.current].color, colors[indexer.next].color, colors[indexer.current].duration, false);
        }







    }

}
