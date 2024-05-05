using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject failedLevelUI;

    bool gameEnded = false;

    public void GameOver()
    {
        if (gameEnded == false) 
        {
            failedLevelUI.SetActive(true);
            Invoke("Restart", 2f);
            gameEnded = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Inputtry");  
    }

    public void Victory()
    {
        completeLevelUI.SetActive(true);
        Invoke("MainMenu", 2f);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}


