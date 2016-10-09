using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {

    public float speed;

    Renderer bgRenderer;

    void Awake() {
        bgRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate() {
        //讓材質球 Shader 做平移
        var setY = bgRenderer.material.GetTextureOffset("_MainTex").y;
        bgRenderer.material.SetTextureOffset("_MainTex",new Vector2(0,setY + speed));
    }
}
