using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene((int)Levels.Level1);
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene((int)Scenes.ControlsMenu);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene((int)Scenes.SettingsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
