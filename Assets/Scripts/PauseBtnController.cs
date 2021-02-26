using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBtnController : MonoBehaviour
{
    [SerializeField]
    Canvas PauseUi;
    [SerializeField]
    Canvas PlayerUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResumeGame() 
    {
        Debug.Log("Resuming Game...");
        Time.timeScale = 1;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
