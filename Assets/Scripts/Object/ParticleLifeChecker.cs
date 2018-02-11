using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ParticleLifeChecker : MonoBehaviour {
    [SerializeField]
    private ParticleSystem _particleSystem;

    private void Awake() {
        this.ObserveEveryValueChanged(_ => _particleSystem.IsAlive())
             .Where(x => !x)
             .Subscribe(_ => Destroy(gameObject));
    }
}
