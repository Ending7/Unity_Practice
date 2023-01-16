using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;  
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();    
        anim = GetComponent<Animator>();    
    }

    private void FixedUpdate()
    {
        // 현재 timestep이 0.02니까 1초에 50번 수행이 된다.
        // time.fiexdDeltaTime을 곱하면 1/50을 곱하는 셈이니 1초 뒤에는 올바른 inputvec*speed의 값이 나온다. 
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {      
            spriter.flipX = inputVec.x < 0;
        }
        
    }
}
