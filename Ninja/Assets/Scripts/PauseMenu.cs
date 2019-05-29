using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton;

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
}
