using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    Rigidbody _myRigidbody;

    public float tumble;

    void Awake() {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    void Start() {
        _myRigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
