using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SortItems
{
    public class CameraFOV : MonoBehaviour
    {
        [SerializeField] float _planeX = 8f;
        [SerializeField] float _planeZ = 8f;
        void Start()
        {
            var _cameraDistance = Vector3.Distance(transform.position,Vector3.zero);
            var camera = GetComponent<Camera>();
            var aspect = (float)Screen.width / Screen.height;

            // FOV по ширине
            var fovWidthRad = 2f * Mathf.Atan((_planeX / 2f) / _cameraDistance);
            float fovWidthVertDeg = 2f * Mathf.Atan(Mathf.Tan(fovWidthRad / 2f) / aspect) * Mathf.Rad2Deg;

            // FOV по длине (Z)
            float fovLengthRad = 2f * Mathf.Atan((_planeZ / 2f) / _cameraDistance);
            float fovLengthDeg = fovLengthRad * Mathf.Rad2Deg;

            camera.fieldOfView = Mathf.Max(fovWidthVertDeg, fovLengthDeg);
        }

    }
}
