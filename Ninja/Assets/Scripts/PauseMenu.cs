using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   /*  public GameObject Pausemenu, PauseButton;

    public void Toggle(bool pause)
    {
        Pausemenu.SetActive (pause);
        PauseButton.SetActive (!pause);
        Time.timeScale = pause ? 0 : 1;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle(!Pausemenu.activeSelf);
        }
    }
    */

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();     
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
