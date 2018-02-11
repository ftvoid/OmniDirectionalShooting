using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D");

        // TODO : 自機ショットかどうかの判定処理見直し
        var shot = collision.GetComponent<PlayerShotMover>();
        if ( shot != null ) {
            // TODO : 爆発処理
            Destroy(gameObject);
        }
    }
}
