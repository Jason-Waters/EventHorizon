using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool isPaused;
    public GameObject pauseMenu;
    public Camera fpsCam;

    void Update()
    {
        
       if(Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
                
            }
        }
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        
        Cursor.visible = true;

        Time.timeScale = 0f;


    }


    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        
    }
 

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
