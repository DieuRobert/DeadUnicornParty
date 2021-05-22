using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuDemarer : MonoBehaviour
{
    [SerializeField]
    private Animator transitionAnim;
    [SerializeField]
    private string sceneName;

    public void StartTheGame()
    {
        //SceneManager.LoadScene("jeu2d");
        Time.timeScale = 1;
        Score.scoreValue = 0;
        StartCoroutine(LoadScene());
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
        //SceneManager.LoadScene("jeu2d");


    }

}
