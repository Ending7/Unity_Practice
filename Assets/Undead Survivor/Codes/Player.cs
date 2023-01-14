using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //내가 입력한 키보드 좌표를 정규화시키고 프레임보정한값 곱한다.
        rigid.MovePosition(rigid.position + nextVec);
    }
}
