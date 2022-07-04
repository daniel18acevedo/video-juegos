using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private Animator _playerAnimator;
    private SpriteRenderer _playerSpriteRenderer;
    private BoxCollider2D _playerCollider;

    [SerializeField] private LayerMask _jumpableGround;

    private float _directionX;
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 14f;


    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling,
    }

    [SerializeField] private AudioSource _jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        this._playerRigidBody = GetComponent<Rigidbody2D>();
        this._playerAnimator = GetComponent<Animator>();
        this._playerSpriteRenderer = GetComponent<SpriteRenderer>();
        this._playerCollider = GetComponent<BoxCollider2D>();

        this._directionX = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        this._directionX = Input.GetAxisRaw("Horizontal");

        this.UpdateVelocityState();

        this.UpdateAnimationState();
    }

    private void UpdateVelocityState()
    {
        //When player is dead
        if (this._playerRigidBody.bodyType != RigidbodyType2D.Static)
        {
            this._playerRigidBody.velocity = new Vector2(this._directionX * this._moveSpeed, this._playerRigidBody.velocity.y);

            if (Input.GetButtonDown("Jump") && this.IsPlayerInGround())
            {
                this._playerRigidBody.velocity = new Vector2(this._playerRigidBody.velocity.x, this._jumpForce);
                this._jumpSoundEffect.Play();
            }
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (this._directionX > 0f)
        {
            state = MovementState.Running;
            this._playerSpriteRenderer.flipX = false;
        }
        else if (this._directionX < 0f)
        {
            state = MovementState.Running;
            this._playerSpriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (this._playerRigidBody.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (this._playerRigidBody.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        this._playerAnimator.SetInteger("state", (int)state);
    }

    private bool IsPlayerInGround()
    {
        return Physics2D.BoxCast(this._playerCollider.bounds.center, this._playerCollider.bounds.size, 0f, Vector2.down, .1f, this._jumpableGround);
    }
}
