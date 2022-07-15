using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinController : MonoBehaviour
{
    private Collider2D col;

    public int score = 1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
       
    public void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);

            GameController.gameController.totalScore += score;
            GameController.gameController.UpdateScoreText();
        }
    }



}
