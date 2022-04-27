using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    private Rigidbody2D rb2D;

    private BoxCollider2D boxCol;

    [SerializeField] private float speed, jumpSpeed;

    [SerializeField] private LayerMask floor;
    public float fallMultiplier = 2.5f;

    public int currentHealth;
    public HealthBar healthBar;

    public CountDownController countDown;

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        rb2D = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    private void Start()
    {
        playerActionControls.Land.Jump.performed += _ => Jump();
        currentHealth = 3;
        healthBar.SetMaxHealth(currentHealth);
        countDown.ResetTime();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= Mathf.Abs(boxCol.bounds.extents.x);
        topLeftPoint.y += Mathf.Abs(boxCol.bounds.extents.y);

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += Mathf.Abs(boxCol.bounds.extents.x);
        bottomRightPoint.y -= Mathf.Abs(boxCol.bounds.extents.y);

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, floor);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyVoid")
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);

            if (currentHealth == 0 || other.gameObject.tag == "EnemyVoid")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //CAMBIAR POR QUITAR VIDA HASTA QUE QUEDE EN 0, ENTONCES SI RECARGO ESCENA
            }
        }

        if (other.gameObject.tag == "WinGem") //VICTORIA
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //MOSTRAR VICTORIA
        }
    }

    void Update()
    {
        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        float movementInput = playerActionControls.Land.Move.ReadValue<float>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;

        countDown.IncreaseCountDown();
    }

}