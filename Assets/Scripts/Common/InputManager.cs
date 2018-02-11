using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 入力管理クラス
/// </summary>
public class InputManager : SingletonMonoBehaviour<InputManager> {
    public struct DragParam {
        public Vector2 Position;
        public Vector2 Delta;
    }

    private Subject<Unit> _onDown = new Subject<Unit>();
    private Subject<Unit> _onUp = new Subject<Unit>();
    private Subject<DragParam> _onDrag = new Subject<DragParam>();

    public static bool IsPressed => Input.GetMouseButton(0);
    public static Vector2 Position => Input.mousePosition;
    public static IObservable<Unit> OnDown => Instance._onDown;
    public static IObservable<Unit> OnUp => Instance._onUp;
    public static IObservable<DragParam> OnDrag => Instance._onDrag;

    private Vector2 _prevPosition;
    private Vector2 _dragDelta;

    protected override void Awake() {
        base.Awake();

        this.ObserveEveryValueChanged(_ => IsPressed)
            .Subscribe(OnPressChanged);

        // TODO : Thresholdの実装はこれから
        this.ObserveEveryValueChanged(_ => Position)
            .Where(_ => IsPressed)
            .Subscribe(OnPositionChanged);

        _prevPosition = Position;
    }

    private void OnPressChanged(bool isPressed) {
        if ( isPressed ) {
            _onDown.OnNext(Unit.Default);
        } else {
            _onUp.OnNext(Unit.Default);
        }
    }

    private void OnPositionChanged(Vector2 pos) {
        _dragDelta = pos - _prevPosition;
        _prevPosition = pos;

        _onDrag.OnNext(new DragParam {
            Position = pos,
            Delta = _dragDelta,
        });
    }
}
