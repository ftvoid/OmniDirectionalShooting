﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUtil : SingletonMonoBehaviour<TransformUtil> {
    [SerializeField]
    private Camera _targetCamera;

    public static Camera TargetCamera => Instance._targetCamera;

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

        return targetCamera.ScreenToWorldPoint(screenPos);
    }
}
