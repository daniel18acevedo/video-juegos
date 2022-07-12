using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Start()
    {
        var audioVolume = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = audioVolume;
    }
    public void StartGame()
    {
        PlayerStats.ResetStats();
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

    public void CreditsMenu()
    {
        SceneManager.LoadScene((int)Scenes.CreditsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
