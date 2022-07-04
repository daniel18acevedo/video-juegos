using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
