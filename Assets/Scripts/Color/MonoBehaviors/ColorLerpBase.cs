using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;


namespace SneakawayUtilities
{
    public class ColorLerpBase : MonoBehaviour
    {
        [Header("ColorLerpBase")]

        [Tooltip("Event to act on")]
        public OnEvent onEvent;
        public enum OnEvent { None, Awake, Enable, Start };

        [Tooltip("Transition is automatic")]
        public bool autoTransition = true;

        [Tooltip("Color transition is in progress")]
        public bool inProgress;

        [Tooltip("Lerp time")]
        public float time = 0;

        [Tooltip("The color that should be inherited by material, sprite, light, etc.")]
        public Color color;

        [Tooltip("List of colors to transition. First color is starting color, duration is how long to transition to next")]
        public List<ColorTools.ColorTransition> colors;

        [Tooltip("Current color")]
        public TimeTools.Indexer indexer;


        protected virtual void Awake()
        {
            indexer = new TimeTools.Indexer(colors.Count);
            if (onEvent == OnEvent.Awake) inProgress = true;
        }

        void Start()
        {
            if (onEvent == OnEvent.Start) inProgress = true;
        }

        void Update()
        {
            // an older, simpler time
            //material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));

            // update this with autoTransition
            if (autoTransition && ColorTools.AreEqual(color, colors[indexer.next].color))
            { 
                indexer.NextIndex();
                time = 0;
            }
            if (inProgress) ChangeColor();
        }

        protected virtual void ChangeColor() { }

    }

}
