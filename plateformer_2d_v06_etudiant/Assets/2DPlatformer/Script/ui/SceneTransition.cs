using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    private const string SceneName = "02_level01";

    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
        Score.scoreValue = 0;
       
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
