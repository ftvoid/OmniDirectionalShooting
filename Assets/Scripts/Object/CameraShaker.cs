using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour {
    [SerializeField]
    private float _duration = 1;
    [SerializeField]
    private float _strength = 1;

    private void Start() {
        TransformUtil
            .TargetCamera
            .DOShakePosition(_duration, _strength)
            .OnComplete(OnAdjust);
    }

    private void OnAdjust() {
        var targetCamera = TransformUtil.TargetCamera;

        if ( targetCamera.transform.position != TransformUtil.InitCameraPosition ) {
            targetCamera.transform
                .DOMove(TransformUtil.InitCameraPosition, 1f);
        }
    }
}
