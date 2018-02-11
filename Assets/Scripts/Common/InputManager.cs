using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 入力管理クラス
/// </summary>
public class InputManager : SingletonMonoBehaviour<InputManager> {
    private Subject<Unit> _onDown = new Subject<Unit>();
    private Subject<Unit> _onUp = new Subject<Unit>();
    private Subject<Vector2> _onDrag = new Subject<Vector2>();

    public static bool IsPressed => Input.GetMouseButton(0);
    public static Vector2 Position => Input.mousePosition;
    public static IObservable<Unit> OnDown => Instance._onDown;
    public static IObservable<Unit> OnUp => Instance._onUp;
    public static IObservable<Vector2> OnDrag => Instance._onDrag;

    protected override void Awake() {
        base.Awake();

        this.ObserveEveryValueChanged(_ => IsPressed)
            .Subscribe(x => {
                if ( x ) {
                    _onDown.OnNext(Unit.Default);
                } else {
                    _onUp.OnNext(Unit.Default);
                }
            });

        // TODO : Thresholdの実装はこれから
        this.ObserveEveryValueChanged(_ => Position)
            .Where(_ => IsPressed)
            .Subscribe(x => _onDrag.OnNext(x));
    }
}
