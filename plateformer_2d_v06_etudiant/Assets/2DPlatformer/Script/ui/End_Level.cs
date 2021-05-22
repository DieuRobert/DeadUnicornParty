using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Level : MonoBehaviour
{
    // private GameObject Button_pause;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private bool newScene;

    private void Start()
    {
       // Button_pause = GameObject.Find("ui");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (newScene == true)
            {
                SceneManager.LoadScene(sceneName);
            }
            if (newScene == false)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
            
            //SceneManager.LoadScene("menu_ecran_win", LoadSceneMode.Additive);
            // Time.timeScale = 0;
            // Button_pause.SetActive(false);
        }
    }
}
