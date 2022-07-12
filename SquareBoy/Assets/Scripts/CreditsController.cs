using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    private void Start()
    {
        var audioVolume = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = audioVolume;
    }

    public void BackToStartMenu()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }
}
