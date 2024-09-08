using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Sprite idleSprite;
    public Sprite runSprite1;
    public Sprite runSprite2;
    public Sprite airSprite;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = true;
    private float animationTimer = 0f;

    private float animationInterval = 0.1f;

    private bool isRunningSprite1 = true;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;

    }

    void Update() {

        Move();
        Jump();
        Animate();

    }

    private void Move() {
        float moveInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);

        if (moveInput > 0) {
            transform.localScale = new Vector3(3,3,3);
        }
        else if (moveInput < 0) {
            transform.localScale = new Vector3(-3,3,3);
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void Animate() {
        float moveInput = Input.GetAxis("Horizontal");
        if (!isGrounded) {
            spriteRenderer.sprite = airSprite;
        }
        else {
            if(Mathf.Approximately(moveInput, 0)) {
                spriteRenderer.sprite = idleSprite;
            }
            else {
                animationTimer += Time.deltaTime;
                if (animationTimer >= animationInterval) {
                    animationTimer = 0f;
                    if (isRunningSprite1) {
                        spriteRenderer.sprite = runSprite1;
                    }
                    else {
                        spriteRenderer.sprite = runSprite2;
                    }
                    isRunningSprite1 = !isRunningSprite1;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }

}
