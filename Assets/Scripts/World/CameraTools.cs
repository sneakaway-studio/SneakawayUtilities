using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

namespace SneakawayUtilities
{
    public static class CameraTools
    {
        static Camera cam = Camera.main;

        /////////////////////////////////
        ///////////// WORLD /////////////
        /////////////////////////////////

        public static float GetCameraAspectRatio()
        {
            // width / height
            return (float)Screen.width / (float)Screen.height;
        }
        public static float GetCameraHeight()
        {
            // The orthographicSize is half the size of the vertical viewing volume.
            // The horizontal size of the viewing volume depends on the aspect ratio.
            return cam.orthographicSize * 2;
        }

        // THIS NEEDS TO BE IMPROVED / TESTED
        public static Vector2 ReturnCameraBounds()
        {
            float aspectRatio = GetCameraAspectRatio();
            float cameraHeight = GetCameraHeight();
            Debug.Log("ReturnCameraBounds() aspectRatio = " + aspectRatio);
            Debug.Log("ReturnCameraBounds() cameraHeight = " + cameraHeight);
            Debug.Log("ReturnCameraBounds() " + new Vector2(cam.orthographicSize * aspectRatio, cameraHeight));
            return new Vector2(cam.orthographicSize * aspectRatio, cameraHeight);
        }


    }
}
