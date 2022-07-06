using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
    private bool _gameInPause;

    private void Start()
    {
        this._pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this._gameInPause)
            {
                this.Play();
            }
            else
            {
                this.Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        this._pauseButton.SetActive(false);
        this._pauseMenu.SetActive(true);
        this._gameInPause = true;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        this._pauseButton.SetActive(true);
        this._pauseMenu.SetActive(false);
        this._gameInPause = false;
    }

    public void Restart()
    {
        this._gameInPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        this._gameInPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
