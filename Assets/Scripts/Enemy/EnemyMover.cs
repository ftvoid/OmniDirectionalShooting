using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour {
    [SerializeField]
    private float _moveUnitMin = 1;
    [SerializeField]
    private float _moveUnitMax = 1;

    private void Start() {
        OnMove();
    }

    private void OnMove() {
        var moveDist = UnityEngine.Random.Range(_moveUnitMin, _moveUnitMax);
        var direction = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;
        var nextPos = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction)) * moveDist;

        transform.DOMove(nextPos, 1).SetRelative(true).OnComplete(OnMove);
    }
}
