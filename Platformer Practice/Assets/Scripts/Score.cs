using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /***************************************************************************************
* Title: Score
* Author: Damz Games
* Date: 2020
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=cOW_T3i4_kk&t=109s
***************************************************************************************/

    public Text scoreText;
    private int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        scoreText.text = "Score:" + ScoreNum;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")
        {
            ScoreNum += 1;
            Destroy(other.gameObject);
            scoreText.text = "Score:" + ScoreNum;
        }
    }
 
}
