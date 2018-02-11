using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMover : MonoBehaviour {
    private void Start() {
        InputManager.OnDrag.Subscribe(OnMove).AddTo(this);
    }

    private void OnMove(InputManager.DragParam param) {
        transform.position += (Vector3)param.Delta * TransformUtil.PixelToWorld;
    }
}
