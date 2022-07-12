using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [Header("For death")]
    [SerializeField] private AudioSource _deathSoundEffect;

    [Header("For text")]
    [SerializeField] private TextMeshProUGUI _lifesText;

    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        this._playerAnimator = GetComponent<Animator>();
        this._playerRigidBody = GetComponent<Rigidbody2D>();
        this._lifesText.text = $"{PlayerStats.LifesLeft}";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            this.Die();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.RemoveLife();
        }

        if(PlayerStats.LifesLeft <= 0)
        {
            PlayerStats.AddMelons(ItemCollector.Melons);

            SceneManager.LoadScene((int)Scenes.GameOverMenu);
        }
    }

    private void Die()
    {
        this._playerAnimator.SetTrigger("death");
        this._playerRigidBody.bodyType = RigidbodyType2D.Static;
        this._deathSoundEffect.Play();
        this.RemoveLife();
    }

    private void RemoveLife()
    {
        PlayerStats.RestLife();
        this._lifesText.text = $"{PlayerStats.LifesLeft}";
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
