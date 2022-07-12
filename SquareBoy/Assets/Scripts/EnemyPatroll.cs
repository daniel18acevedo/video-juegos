using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idel = 0,
    Patrolling = 1,
}

public class EnemyPatroll : WaypointFollower
{
    [Header("Enemy")]
    [SerializeField] private BoxCollider2D _enemyBodyCollider;
    [SerializeField] private BoxCollider2D _enemyHeaderCollider;

    private Animator _enemyAnimator;
    private SpriteRenderer _enemySpritRenderer;
    private bool _facingRight;
    private bool _enemyAlive = true;

    protected override void Start()
    {
        this._enemySpritRenderer = base.GetComponent<SpriteRenderer>();
        this._enemyAnimator = base.GetComponent<Animator>();
    }

    protected override void Move()
    {
        if (this._enemyAlive && this._enemyAnimator.GetInteger("state") == (int)EnemyState.Patrolling)
        {
            base.Move();

            if (base._changeDirection)
            {
                this._facingRight = !this._facingRight;
                this._enemySpritRenderer.flipX = this._facingRight;
            }

            base._changeDirection = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this._enemyAlive = false;
            this._enemyAnimator.SetTrigger("death");
        }
    }

    public void KillEnemy()
    {
        Destroy(this._enemyBodyCollider);
        Destroy(this._enemyHeaderCollider);
    }
}
