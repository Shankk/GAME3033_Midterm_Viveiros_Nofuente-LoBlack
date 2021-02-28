using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUiController : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas WinMenu;
    public GameObject WinConditon;

    public void ResumeGame() 
    {
        Debug.Log("Resuming Game...");
        pauseMenu.enabled = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("LevelOne");
        pauseMenu.enabled = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Win")
        {
            WinMenu.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
