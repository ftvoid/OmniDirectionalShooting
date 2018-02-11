using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseOnHide : MonoBehaviour {
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
