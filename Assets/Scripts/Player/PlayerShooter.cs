using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {
    [SerializeField]
    private PlayerShotMover _shot;

    [SerializeField]
    private float _reloadTime = 0.5f;

    [SerializeField]
    private float _shootSpeed = 1f;

    private float _lastShootTime;

    private void Awake() {
        _lastShootTime = 0;
    }

    private void Update() {
        if ( InputManager.IsPressed ) {
            var time = Time.time;
            if ( time >= _lastShootTime + _reloadTime ) {
                _lastShootTime = time;

                var shot = Instantiate(_shot, transform.position, transform.rotation);
                var angle = transform.eulerAngles.z;

                shot.Velocity = Quaternion.Euler(0, 0, angle) * Vector2.up * _shootSpeed;
            }
        }
    }
}
