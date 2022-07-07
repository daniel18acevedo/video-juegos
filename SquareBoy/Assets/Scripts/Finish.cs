using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource _finishSoundEffect;
    private bool _levelCompleted = false;

    private void Start()
    {
        this._finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !this._levelCompleted)
        {
            this._finishSoundEffect.Play();
            this._levelCompleted = true;
            base.Invoke(nameof(this.CompleteLevel), 2f);
        }
    }

    private void CompleteLevel()
    {
        var indexCurrentLevel = SceneManager.GetActiveScene().buildIndex;
        
        var sceneToLoad = (int)Scenes.WinnerMenu;
        
        if(indexCurrentLevel != (int)Levels.Level2)
        {
            var levels = Enum.GetValues(typeof(Levels)).Cast<Levels>();
            var nextLevel = levels.First(level => (indexCurrentLevel+1) == (int)level);

            sceneToLoad= (int)nextLevel;
        }
        
        SceneManager.LoadScene(sceneToLoad);
    }
}
