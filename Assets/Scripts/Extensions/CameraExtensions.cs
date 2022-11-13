using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SneakawayUtilities
{
    public static class CameraExtensions
    {
        static Camera cam = Camera.main;

        /////////////////////////////////
        ///////////// WORLD /////////////
        /////////////////////////////////

        public static float GetCameraAspectRatio()
        {
            return (float)Screen.width / (float)Screen.height;
        }
        public static float GetCameraHeight()
        {
            return cam.orthographicSize * 2;
        }

        public static Vector2 ReturnCameraBounds()
        {
            float aspectRatio = GetCameraAspectRatio();
            float cameraHeight = GetCameraHeight();
            Debug.Log("aspectRatio = " + aspectRatio);
            Debug.Log("cameraHeight = " + cameraHeight);
            Debug.Log("bounds = " + new Vector2(cam.orthographicSize * aspectRatio, cameraHeight));
            return new Vector2(cam.orthographicSize * aspectRatio, cameraHeight);
        }


    }
}
