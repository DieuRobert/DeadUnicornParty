using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuPause : MonoBehaviour
{
    public static bool ShowGui = false;
    private bool menuPause = false;
    private GameObject Button_pause ;

    private void Start()
    {
        Button_pause = GameObject.Find("Button_pause");
    }
    public void StartPause()
    {
       ShowGui = !ShowGui;
    
       
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
    public void NewGame ()
    {
        SceneManager.LoadScene("02_level01");
        SceneManager.UnloadSceneAsync("menu_pause");
        ShowGui = false;
        Score.scoreValue = 0;
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowGui = !ShowGui;

        }

        if (ShowGui == true)
        {
            if (menuPause == false)
            {
                SceneManager.LoadScene("menu_pause", LoadSceneMode.Additive);
            
                menuPause = true;
                Time.timeScale = 0;
                Button_pause.SetActive(false);
            }
        }
        else
        {
            if (menuPause == true)
            {
                SceneManager.UnloadSceneAsync("menu_pause");
                menuPause = false;
                Time.timeScale = 1;
                Button_pause.SetActive(true);
            }
        }
    }
}