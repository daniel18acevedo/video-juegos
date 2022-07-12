using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyPatroll : MonoBehaviour
{
    [Header("For Enemy")]
    [SerializeField] private GameObject _enemy;

    private Animator _enemyAnimator;

    private void Start()
    {
        this._enemyAnimator = this._enemy.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this._enemyAnimator.SetInteger("state", (int)EnemyState.Patrolling);
        }
    }
}
