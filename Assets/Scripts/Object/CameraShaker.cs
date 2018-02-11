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
        TransformUtil.TargetCamera.DOShakePosition(_duration, _strength);
    }
}
