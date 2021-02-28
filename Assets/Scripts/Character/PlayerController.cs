using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsJumping;
    public bool IsRunning;

    public bool gamePaused = false;
    public Canvas pauseMenu;

    public void OnPause(InputValue button)
    {
        if (gamePaused == false)
        {   
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            gamePaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseMenu.enabled = false;
            Cursor.visible = false;
            gamePaused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
