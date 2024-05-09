using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SneakawayUtilities;

namespace SneakawayUtilities
{
    public class ColorLerpImage : ColorLerpBase
    {
        // ColorLerpBase fields here ...


        [Header("ColorLerpImage")]
        
        [Tooltip("Image for this game object")]
        public Image image;

        // overriding so to get references
        protected override void Awake()
        {
            image = GetComponent<Image>();
            base.Awake();
        }
   
        protected override void ChangeColor() 
        {
            // change local color
            LerpImageColor();
            // set component color
            image.color = color;
        }

        void LerpImageColor()
        {
            // update time    
            time += Time.deltaTime / colors[indexer.current].duration;
            // time = Mathf.PingPong(Time.time, 1); // ping pong test

            // change color
            color = Color.Lerp(colors[indexer.current].color, colors[indexer.next].color, time);
        }


    }
}
