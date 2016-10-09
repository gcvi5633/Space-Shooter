using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    //邊界值的設定值
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    Rigidbody _myRigidbody;
    AudioSource _myAudioSource;

    public Boundary boundary;

    public float speed;
    public float tilt;

    public GameObject shotPrefab;
    public Transform shotSpawn;

    [Header("連射速度")]
    public float shotTime;
    private float lifeTime;

    void Awake() {
        _myRigidbody = GetComponent<Rigidbody>();
        _myAudioSource = GetComponent<AudioSource>();
    }

    void Update() {
        //按下Z發射子彈，可以連射
        if(Input.GetKey(KeyCode.Z) && Time.time > lifeTime) {
            lifeTime = Time.time + shotTime;
            Instantiate(shotPrefab,shotSpawn.position,shotSpawn.rotation);
            _myAudioSource.Play();
        }
    }

    void FixedUpdate() {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        var movement = new Vector3(moveH,0,moveV);
        _myRigidbody.velocity = movement * speed;

        //控制飛機的邊界
        _myRigidbody.position = new Vector3(
            Mathf.Clamp(_myRigidbody.position.x,boundary.xMin,boundary.xMax),
            0.0f,
            Mathf.Clamp(_myRigidbody.position.z,boundary.zMin,boundary.zMax)
            );

        //讓飛機有轉向的動作
        _myRigidbody.rotation = Quaternion.Euler(0.0f,0.0f,_myRigidbody.velocity.x * -tilt);
    }
}
