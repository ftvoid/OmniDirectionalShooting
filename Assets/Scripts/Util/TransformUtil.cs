using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUtil : SingletonMonoBehaviour<TransformUtil> {
    [SerializeField]
    private Camera _targetCamera;

    [SerializeField]
    private Transform _targetTransform;

    public static Camera TargetCamera => Instance._targetCamera;
    public static Transform TargetTransform => Instance._targetTransform;

    public static float PixelToWorld => GetPixelToWorld();

    public static float GetPixelToWorld(Camera targetCamera = null) {
        if ( targetCamera == null ) {
            targetCamera = Instance._targetCamera;
        }
        return TargetCamera.orthographicSize * 2 / Screen.height;
    }

    public static Vector2 GetWorldPosition(Vector2 screenPos, Camera targetCamera = null) {
        if ( targetCamera == null ) {
            targetCamera = Instance._targetCamera;
        }

        return new Vector2(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2) * PixelToWorld;
    }

    public static Rect CameraArea {
        get {
            var areaHeight = TargetCamera.orthographicSize * 2;
            var areaWidth = areaHeight * Screen.width / Screen.height;
            return new Rect(-areaWidth / 2, -areaHeight / 2, areaWidth, areaHeight);
        }
    }
}
