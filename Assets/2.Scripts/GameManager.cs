using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int jumpCount;
    public Text coinCount;

    void Awake()
    {
        coinCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SceneManager.LoadScene(0);
    }

    public void GetCoin(int count)
    {
        coinCount.text = count.ToString();

    }
}
