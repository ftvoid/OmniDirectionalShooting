using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private float _delay = 5;

    [SerializeField]
    private float _interval = 10;

    private void Start() {
        Observable.Timer(TimeSpan.FromSeconds(_delay), TimeSpan.FromSeconds(_interval))
            .Subscribe(_ => OnGenerate())
            .AddTo(this);
    }

    private void OnGenerate() {
        var area = TransformUtil.CameraArea;
        var pos = new Vector2(
            UnityEngine.Random.Range(area.xMin, area.xMax),
            UnityEngine.Random.Range(area.yMin, area.yMax));

        Instantiate(_enemy, pos, _enemy.transform.rotation);
    }
}
