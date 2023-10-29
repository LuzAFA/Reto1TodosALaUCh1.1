using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Coin")
        {
            Destroy(collision.gameObject);
            scoreManager.SumScore();
        }
    }
}
