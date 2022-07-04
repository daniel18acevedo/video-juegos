using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidBody;

    [SerializeField] private AudioSource _deathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        this._playerAnimator = GetComponent<Animator>();
        this._playerRigidBody = GetComponent<Rigidbody2D>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            this.Die();
        }
    }

    private void Die()
    {
        this._playerAnimator.SetTrigger("death");
        this._playerRigidBody.bodyType = RigidbodyType2D.Static;
        this._deathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
