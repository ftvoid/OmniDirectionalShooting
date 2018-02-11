using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMarkerMover : MonoBehaviour {
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Vector2 _offset = Vector2.zero;

    public void Update() {
        transform.position = _player.position + (Vector3)_offset;
    }
}
