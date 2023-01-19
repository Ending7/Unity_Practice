using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerLogic : MonoBehaviour
{
    public int totalitemcount;
    public int stage;
    public Text stageCountText;
    public Text PlayerCountText;

    private void Awake()
    {
        stageCountText.text = "/ " + totalitemcount;
    }

    public void GetItem(int count)
    {

        PlayerCountText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(stage);  
    }

   
}
