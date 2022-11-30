using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

namespace SneakawayUtilities
{

    public class ColorLerp : MonoBehaviour
    {
        [Tooltip("List of colors to transition. First color is starting color, duration is how long to transition to next")]
        public List<ColorTools.ColorTransition> colors;

        [Tooltip("Current color")]
        public TimeTools.Indexer indexer;

        [Tooltip("Material for this game object")]
        public Material material;

        void Awake()
        {
            material = GetComponent<Renderer>().material;
            indexer = new TimeTools.Indexer(colors.Count);
            ChangeColor();
        }

        void Update()
        {
            // an older, simpler time
            //material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));

            if (ColorTools.AreEqual(material.color, colors[indexer.next].color))
            {
                ChangeColor();
            }
        }

        void ChangeColor()
        {
            indexer.NextIndex();
            SneakawayUtilities.ColorTools.ChangeMaterialColor(this, material, colors[indexer.current].color, colors[indexer.next].color, colors[indexer.current].duration, false);
        }





    }

}
