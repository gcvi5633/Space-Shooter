using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {

    Rigidbody _myRigbody;

    public float speed;
    void Awake() {
        _myRigbody = GetComponent<Rigidbody>();
    }

	void Start () {
        _myRigbody.velocity = transform.forward*speed;
	}
}
