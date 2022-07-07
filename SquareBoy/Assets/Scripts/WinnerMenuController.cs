using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenuController : MonoBehaviour
{
    
    public void PlayAgainButton()
    {
        SceneManager.LoadScene((int)Levels.Level1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
