using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObject : MonoBehaviour {
    [SerializeField]
    private float _attack = 100;

    [SerializeField]
    private float _life = 100;

    public void AddDamage(float attack) {
        _life -= attack;

        if ( _life <= 0 ) {
            // TODO : 爆発処理実装
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var obj = collision.GetComponent<StageObject>();
        if ( obj == null ) {
            return;
        }

        // 衝突対象にダメージを与える
        obj.AddDamage(_attack);
    }
}
