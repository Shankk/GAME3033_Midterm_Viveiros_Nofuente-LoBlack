using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnController : MonoBehaviour
{
    [SerializeField]
    Canvas MainMenu;
    [SerializeField]
    Canvas Options;
    [SerializeField]
    Canvas Credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void OpenOptions()
    {
        MainMenu.GetComponent<Canvas>().enabled = false;
        Options.GetComponent<Canvas>().enabled = true;
    }

    public void CloseOptions()
    {
        Options.GetComponent<Canvas>().enabled = false;
        MainMenu.GetComponent<Canvas>().enabled = true;
    }

    public void OpenCredits()
    {
        MainMenu.GetComponent<Canvas>().enabled = false;
        Credits.GetComponent<Canvas>().enabled = true;
    }

    public void CloseCredits()
    {
        Credits.GetComponent<Canvas>().enabled = false;
        MainMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ExitGameApp()
    {
        Debug.Log("Quiting Game Application");
        Application.Quit();
    }
}
