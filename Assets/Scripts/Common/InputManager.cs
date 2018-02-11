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

    public static bool IsPressed => Input.GetMouseButton(0);
    public static IObservable<Unit> OnDown => Instance._onDown;
    public static IObservable<Unit> OnUp => Instance._onUp;

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
    }
}
