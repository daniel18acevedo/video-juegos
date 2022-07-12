using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovementState
{
    Idle,
    Running,
    Jumping,
    Falling,
    Sliding,
    Pushed
}
public class PlayerMovement : MonoBehaviour
{

    [Header("For Movement")]
    [SerializeField] private float _moveSpeed = 7f;
    private float _directionX;
    private bool _facingRight = true;
    private bool _isMoving;

    [Header("For Jumping")]
    [SerializeField] private LayerMask _jumpableGround;
    [SerializeField] private float _jumpForce = 14f;
    private bool _grounded;
    private bool _isJumping;
    private bool _isFalling = true;
    private bool _canJump;

    [Header("Wall")]
    [SerializeField] private LayerMask _jumpableWall;
    private float _wallSlideSpeed;
    private bool _isTouchingWall;
    private bool _isWallSliding;

    [Header("For WallJumping")]
    [SerializeField] float _walljumpforce = 14f;
    Vector2 _walljumpAngle = new(1, 1);
    [SerializeField] float _walljumpDirection = -1;

    [Header("For pushed")]
    [SerializeField] private float _forcePushedY = 3f;
    [SerializeField] private float _forcePushedX = 7f;
    [SerializeField] private AudioSource _pushedSoundEffect;
    private bool _isPushed;

    private bool _isAboveEnemy;

    [Header("Other")]
    [SerializeField] private AudioSource _jumpSoundEffect;
    private Rigidbody2D _playerRigidBody;
    private Animator _playerAnimator;
    private SpriteRenderer _playerSpriteRenderer;
    private BoxCollider2D _playerCollider;


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
        this.Inputs();
        this.CheckWorld();
        this.AnimationControl();
    }

    private void Inputs()
    {
        this._directionX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (this._grounded || this._isWallSliding))
        {
            this._canJump = true;
        }
    }

    private void CheckWorld()
    {
        this._grounded = Physics2D.BoxCast(this._playerCollider.bounds.center, this._playerCollider.bounds.size, 0f, Vector2.down, .1f, this._jumpableGround);

        if (this._grounded)
        {
            this._isFalling = false;
            this._isJumping = false;
        }
        else if (!this._isTouchingWall)
        {
            if (this._playerRigidBody.velocity.y > .1f)
            {
                this._isFalling = false;
                this._isJumping = true;
            }
            else if (this._playerRigidBody.velocity.y < -.1f)
            {
                this._isJumping = false;
                this._isFalling = true;
            }
        }

        this._isTouchingWall = Physics2D.BoxCast(this._playerCollider.bounds.center, this._playerCollider.bounds.size, 0f, this._facingRight ? Vector2.right : Vector2.left, .1f, this._jumpableWall);
    
        if(this._grounded || this._isFalling || this._isJumping || this._isTouchingWall)
        {
            this._isAboveEnemy = false;
        }
    }

    private void AnimationControl()
    {
        var state = MovementState.Idle;

        if (this._grounded)
        {
            state = MovementState.Idle;
        }

        if (this._isMoving)
        {
            state = MovementState.Running;
        }

        if (this._isJumping)
        {
            state = MovementState.Jumping;
        }

        if (this._isFalling)
        {
            state = MovementState.Falling;
        }

        if (this._isWallSliding)
        {
            state = MovementState.Sliding;
        }

        if (this._isMoving && this._isTouchingWall && this._grounded)
        {
            state = MovementState.Idle;
        }

        if (this._isPushed)
        {
            state = MovementState.Pushed;
        }

        this._playerAnimator.SetInteger("state", (int)state);
    }

    private void FixedUpdate()
    {
        var isPlayerAlived = this._playerRigidBody.bodyType != RigidbodyType2D.Static;

        if (isPlayerAlived && !this._isPushed && !this._isAboveEnemy)
        {
            this.Movement();
            this.Jump();
            this.WallSlide();
            this.WallJump();
        }
    }

    private void Movement()
    {
        //for Animation
        this._isMoving = this._directionX != 0;

        //For movement
        this._playerRigidBody.velocity = new Vector2(this._directionX * this._moveSpeed, this._playerRigidBody.velocity.y);

        //For fliping
        if (this._directionX < 0f && this._facingRight)
        {
            this.Flip();
        }
        else if (this._directionX > 0f && !this._facingRight)
        {
            this.Flip();
        }
    }

    private void Flip()
    {
        if (!this._isWallSliding)
        {
            this._walljumpDirection *= -1;
            this._facingRight = !this._facingRight;
            this._playerSpriteRenderer.flipX = !this._facingRight;
        }
    }

    private void Jump()
    {
        if (this._canJump && this._grounded)
        {
            this._playerRigidBody.velocity = new Vector2(this._playerRigidBody.velocity.x, this._jumpForce);
            this._jumpSoundEffect.Play();
            this._canJump = false;
        }
    }

    private void WallSlide()
    {
        if (this._isTouchingWall && !this._grounded && this._playerRigidBody.velocity.y != .1f)
        {
            this._isWallSliding = true;
        }
        else
        {
            this._isWallSliding = false;
        }

        if (this._isWallSliding)
        {
            this._playerRigidBody.velocity = new Vector2(this._playerRigidBody.velocity.x, -this._wallSlideSpeed);
        }
    }

    void WallJump()
    {
        if (this._canJump && this._isWallSliding)
        {
            this._playerRigidBody.AddForce(new Vector2(this._walljumpforce * this._walljumpAngle.x * this._walljumpDirection, this._walljumpforce * this._walljumpAngle.y), ForceMode2D.Impulse);
            this._jumpSoundEffect.Play();
            this._canJump = false;
            this._isWallSliding = false;
            this.Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !this._isAboveEnemy)
        {
            this._isPushed = true;
            this._pushedSoundEffect.Play();
            var directionOfPush = this._facingRight ? (this._forcePushedX * -1) : this._forcePushedX;

            this._playerRigidBody.AddForce(new Vector2(directionOfPush, this._forcePushedY), ForceMode2D.Impulse);
        }
    }

    public void FinishPushed()
    {
        this._isPushed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var directionOfPush = this._facingRight ? this._forcePushedX: (this._forcePushedX * -1);

            this._playerRigidBody.AddForce(new Vector2(directionOfPush, 10), ForceMode2D.Impulse);
            this._isAboveEnemy = true;
        }
    }
}
