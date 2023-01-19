using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBall : MonoBehaviour
{
    bool isjump = true;
    public float jumpPower;
    public int itemcount;
    Rigidbody rigid;
    AudioSource audio;
    public GameManagerLogic manager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isjump)
        {
            isjump = false;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isjump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemcount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemcount);
      
        }

        else if (other.tag == "Finish")
        {
            if (itemcount == manager.totalitemcount)
            {
                if (manager.stage == 2) 
                     SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);
            }

            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
