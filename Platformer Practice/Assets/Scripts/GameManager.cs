using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   //Creating a respawn delay and death mecahanic
    bool gamehasEnded = false;
    public float restartDelay = 0;
    /***************************************************************************************
 * Title: Winning Levels
 * Author: Brackeys
 * Date: 2017
 * Code version: N/A
 * Availability: https://www.youtube.com/watch?v=Iv7A8TzreY4&t=254s
 ***************************************************************************************/
    public GameObject completeLevelUI;
    //Creating win condition
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    //Creating lose condition
    public void EndGame()
    {
        if(gamehasEnded == false)
        {
            gamehasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }
    //Creating respawn condition
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
