using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotMover : MonoBehaviour {
    [SerializeField]
    private Vector2 _velocity = Vector2.zero;

    public Vector2 Velocity {
        get { return _velocity; }
        set {
            _velocity = value;
            var angle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Update() {
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }
}
