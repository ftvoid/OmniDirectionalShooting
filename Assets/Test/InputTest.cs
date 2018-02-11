using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputTest : MonoBehaviour {
    private void Start() {
        InputManager.OnDown.Subscribe(_ => Debug.Log("OnDown")).AddTo(this);
        InputManager.OnUp.Subscribe(_ => Debug.Log("OnUp")).AddTo(this);
        InputManager.OnDrag.Subscribe(x => Debug.Log("OnDrag : " + x.ToString())).AddTo(this);
    }
}
