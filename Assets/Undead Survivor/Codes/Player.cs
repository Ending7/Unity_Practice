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
        // ���� timestep�� 0.02�ϱ� 1�ʿ� 50�� ������ �ȴ�.
        // time.fiexdDeltaTime�� ���ϸ� 1/50�� ���ϴ� ���̴� 1�� �ڿ��� �ùٸ� inputvec*speed�� ���� ���´�. 
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
