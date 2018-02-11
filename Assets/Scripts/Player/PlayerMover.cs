using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMover : MonoBehaviour {
    public Vector2 Direction {
        get {
            var angle = transform.rotation.eulerAngles.z;
            return Quaternion.Euler(0, 0, angle) * Vector2.up;
        }
        set {
            var angle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Start() {
        InputManager.OnDrag.Subscribe(OnMove).AddTo(this);
    }

    private void OnMove(InputManager.DragParam param) {
        transform.position += (Vector3)param.Delta * TransformUtil.PixelToWorld;
    }
}
