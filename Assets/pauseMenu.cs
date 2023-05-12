using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUi;


    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUi.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            
        }

        if (isPaused)
        {
            pauseGame();
        }
        else
        {
            resumeGame();
        }
        
    }

    public void pauseGame()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;

        
    }

    public void resumeGame()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitGame(){
        Debug.Log("quitGame");
        Application.Quit();
    }

}
