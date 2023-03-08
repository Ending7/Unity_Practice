using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    GameManager manager;
    AudioSource Audio;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public int speed;
    public int jumpHeight;
    public float maxSpeed;
    int jumpCount = 0;
    int coinCount;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Audio = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();      
        anim = gameObject.GetComponent<Animator>();     
    }

    private void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && (jumpCount != manager.jumpCount))
        {
            jumpCount++;
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        //StopSpeed
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        
        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 1)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);


    }

    void FixedUpdate()
    {
        //Move By Key Controller
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h , ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)  //Right max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed * (-1)) // Left max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1) , rigid.velocity.y);

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            jumpCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Audio.Play();
            coinCount++;
            manager.GetCoin(coinCount);
            collision.gameObject.SetActive(false);
        }
    }
}
