using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RotationMarkerMover : MonoBehaviour {
    [SerializeField]
    private Transform _player;

    // TODO : クラス間の依存関係を見直したい
    [SerializeField]
    private PlayerMover _playerMover;

    [SerializeField]
    private Vector2 _offset = Vector2.zero;

    private Collider2D _collider;
    private bool _isRotating = false;

    private Vector2 _delta = Vector2.zero;

    private void Awake() {
        _collider = GetComponent<Collider2D>();
    }

    private void Start() {
        InputManager.OnDown.Subscribe(_ => OnDown()).AddTo(this);
        InputManager.OnUp.Subscribe(_ => OnUp()).AddTo(this);
        InputManager.OnDrag.Where(_ => _isRotating).Subscribe(OnMove).AddTo(this);

        _delta = _playerMover.Direction;
    }

    private void Update() {
        transform.position = _player.position + (Vector3)_offset;
    }

    private void OnDown() {
        var pos = TransformUtil.GetWorldPosition(InputManager.Position);
        var hit = Physics2D.Raycast(pos, Vector2.zero);

        if ( hit.collider == _collider ) {
            _isRotating = true;
        }
    }

    private void OnUp() {
        _isRotating = false;
    }

    private void OnMove(InputManager.DragParam param) {
        // TODO : 移動方向の平滑化処理は仮でLerpを使っているが、
        //        後でフレーム依存しない処理に置き換え予定
        _delta = Vector2.Lerp(_delta, param.Delta.normalized, 0.2f);

        _playerMover.Direction = _delta;
    }
}
