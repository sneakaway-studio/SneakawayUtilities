using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

namespace SneakawayUtilities
{

    public class ColorLerpLight : MonoBehaviour
    {
        [Tooltip("List of colors to transition. First color is starting color, duration is how long to transition to next")]
        public List<ColorTools.ColorTransition> colors;

        [Tooltip("Current color")]
        public TimeTools.Indexer indexer;

        [Tooltip("Light on this game object")]
        public ColorInstance colorInstance;

        public Light lightComponent;

        void Awake()
        {
            if (colorInstance == null) colorInstance = GetComponent<ColorInstance>();
            if (lightComponent == null) lightComponent = GetComponent<Light>();
            indexer = new TimeTools.Indexer(colors.Count);
            ChangeColor();
        }

        void Update()
        {
            // an older, simpler time
            //material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));

            if (ColorTools.AreEqual(lightComponent.color, colors[indexer.next].color))
            {
                ChangeColor();
            }
            lightComponent.color = colorInstance.color;
        }

        void ChangeColor()
        {
            indexer.NextIndex();
            ColorTools.ChangeInstanceColor(this, colorInstance, colors[indexer.current].color, colors[indexer.next].color, colors[indexer.current].duration, false);
        }







    }

}
